using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using NSubstitute;
using Xunit;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDateIsOk_Executed_ReturnProjecId()
        {
            //Arrange
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var projecRepositorySubstitute = Substitute.For<IProjectRepository>();
            var skillRepositorySubstitute = Substitute.For<ISkillRepository>();

            unitOfWork.Projects.Returns(projecRepositorySubstitute);
            unitOfWork.Skills.Returns(skillRepositorySubstitute);
                
            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Title",
                Description = "Description",
                TotalCost = 10000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(unitOfWork);

            // Act

            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);

            await projecRepositorySubstitute.Received(1).AddAsync(Arg.Any<Project>());
        }
    }
}
