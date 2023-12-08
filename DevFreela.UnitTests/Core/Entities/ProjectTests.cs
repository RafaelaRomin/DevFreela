using DevFreela.Core.Entities;
using DevFreela.Core.Enums;
using Xunit;

namespace DevFreela.UnitTests.Core.Entities
{
    public class ProjectTests
    {
        [Fact]
        public void TestIfProjectStartWorks()
        {
            var project = new Project("Title test", "Description test", 1, 2, 15000);

            Assert.Equal(ProjectStatusEnum.Created, project.Status);
            Assert.Null(project.StartedAt);

            Assert.NotNull(project.Title);
            Assert.NotEmpty(project.Title);

            Assert.NotEmpty(project.Description);
            Assert.NotNull(project.Description);

            project.Start();

            Assert.Equal(ProjectStatusEnum.InProgress, project.Status);
            Assert.NotNull(project.StartedAt);

        }
    }
}
