using DevFreela.Application.Queries.GelAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using NSubstitute;
using NSubstitute.ExceptionExtensions;
using NSubstitute.ReceivedExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectsViewModels()
        {
            //Arrange
            var projects = new List<Project>()
            {
                new Project("Name project 1", "Description project 1", 1, 2, 15000),
                new Project("Name project 2", "Description project 2", 1, 2, 30000),
                new Project("Name project 3", "Description project 3", 1, 2, 45000),
            };

            var projectRepositorySubstitute = Substitute.For<IProjectRepository>();

            projectRepositorySubstitute.GetAllAsync().Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery("");
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(projectRepositorySubstitute);

            //Act
            var projectViewModelList = await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert

            Assert.NotNull(projectViewModelList);
            Assert.NotEmpty(projectViewModelList);
            Assert.Equal(projects.Count, projectViewModelList.Count);
        

            await projectRepositorySubstitute.Received(1).GetAllAsync();
        }
    }
}
