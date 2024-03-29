﻿using DevFreela.Application.Queries.GelAllProjects;
using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using DevFreela.Infrastructure.Persistence;
using DevFreela.Infrastructure.Persistence.Models;
using NSubstitute;

namespace DevFreela.UnitTests.Application.Queries
{
    public class GetAllProjectsCommandHandlerTests
    {
        [Fact]
        public async Task ThreeProjectsExist_Executed_ReturnThreeProjectsViewModels()
        {
            //Arrange
            var unitOfWork = Substitute.For<IUnitOfWork>();
            var projectRepositorySubstitute = Substitute.For<IProjectRepository>();
            var skillRepositorySubstitute = Substitute.For<ISkillRepository>();

            unitOfWork.Projects.Returns(projectRepositorySubstitute);
            unitOfWork.Skills.Returns(skillRepositorySubstitute);
            
            var projects = new PaginationResult<Project>
            {
                Data = new List<Project>
                {
                    new Project("Name project 1", "Description project 1", 1, 2, 15000),
                    new Project("Name project 2", "Description project 2", 1, 2, 30000),
                    new Project("Name project 3", "Description project 3", 1, 2, 45000),
                }
            };
            
            projectRepositorySubstitute.GetAllAsync(Arg.Any<string?>(), Arg.Any<int>()).Returns(projects);

            var getAllProjectsQuery = new GetAllProjectsQuery{Query = "", Page = 1};
            var getAllProjectsQueryHandler = new GetAllProjectsQueryHandler(unitOfWork);

            //Act
            var paginationProjectViewModelList =
                await getAllProjectsQueryHandler.Handle(getAllProjectsQuery, new CancellationToken());

            //Assert

            Assert.NotNull(paginationProjectViewModelList);
            Assert.NotEmpty(paginationProjectViewModelList.Data);
            Assert.Equal(projects.Data.Count, paginationProjectViewModelList.Data.Count);


            await projectRepositorySubstitute.Received(1).GetAllAsync(Arg.Any<string?>(), Arg.Any<int>());
        }
    }
}