using DevFreela.Application.Commands.CreateProject;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;
using NSubstitute.Core.Arguments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Commands
{
    public class CreateProjectCommandHandlerTests
    {
        [Fact]
        public async Task InputDateIsOk_Executed_ReturnProjecId()
        {
            //Arrange

            var projecRepositorySubstitute = Substitute.For<IProjectRepository>();

            var createProjectCommand = new CreateProjectCommand
            {
                Title = "Title",
                Description = "Description",
                TotalCost = 10000,
                IdClient = 1,
                IdFreelancer = 2,
            };

            var createProjectCommandHandler = new CreateProjectCommandHandler(projecRepositorySubstitute);

            //Act

            var id = await createProjectCommandHandler.Handle(createProjectCommand, new CancellationToken());

            //Assert

            Assert.True(id >= 0);

            await projecRepositorySubstitute.Received(1).AddAsync(Arg.Any<Project>());
        }
    }
}
