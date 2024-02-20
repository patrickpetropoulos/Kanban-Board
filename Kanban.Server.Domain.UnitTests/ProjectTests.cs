using Kanban.Server.Domain.Projects;

namespace Kanban.Server.Domain.UnitTests;

public class ProjectTests
{
  [Fact]
  public void Test_GettingNameFromJsonGivesSameNameAsWasPutIn()
  {
    //Really Basic Test just to get unit testing setup
    var name = new ProjectName("Test Project");

    var project = new Project(Guid.NewGuid(), name);

    var projectToTest = new Project();
    projectToTest.PutJson(project.GetJson());

    Assert.Equal(name, projectToTest.Name);
  }
}