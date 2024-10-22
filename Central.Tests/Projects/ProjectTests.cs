/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ProjectTests                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Project type.                                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Projects;
using Empiria.StateEnums;

namespace Empiria.Tests.Projects {

  /// <summary>Unit tests for Project type.</summary>
  public class ProjectTests {

    [Fact]
    public void Should_Create_Project() {
      var projectType = ProjectType.Parse(TestingConstants.PROJECT_TYPE_ID);
      var name = " Nombre  del proyecto ";

      var sut = new Project(projectType, name);

      Assert.Equal(projectType, sut.ProjectType);
      Assert.Equal(EmpiriaString.Clean(name), sut.Name);
      Assert.Empty(sut.Code);
      Assert.Empty(sut.Description);
    }


    [Fact]
    public void Should_Delete_Project() {
      var sut = Project.Parse(TestingConstants.PROJECT_ID);

      sut.Delete();

      Assert.Equal(EntityStatus.Deleted, sut.Status);
    }


    [Fact]
    public void Should_Get_All_Projects() {
      var sut = Project.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_Project() {
      var sut = Project.Empty;

      Assert.NotNull(sut);
      Assert.NotNull(sut.ProjectType);
      Assert.Equal(ProjectType.Empty, sut.ProjectType);
    }


    [Fact]
    public void Should_Parse_All_Projects() {
      var projects = Project.GetList();

      foreach (var sut in projects) {
        Assert.NotEmpty(sut.Name);
        Assert.NotEmpty(sut.Code);
        Assert.NotEqual(ProjectType.Empty, sut.ProjectType);
      }
    }


    [Fact]
    public void Should_Update_Project() {
      var sut = Project.Parse(TestingConstants.PROJECT_ID);

      var fields = new ProjectFields {
         Code = "  new code ",
         Name = " Este  es  el nuevo  nombre del proyecto ",
         Description = " Esta es la descripción ",
         ProjectTypeUID = TestingConstants.PROJECT_TYPE_ID
      };

      sut.Update(fields);

      Assert.Equal(EmpiriaString.Clean(fields.Code), sut.Code);
      Assert.Equal(EmpiriaString.Clean(fields.Name), sut.Name);
      Assert.Equal(EmpiriaString.Clean(fields.Description), sut.Description);
      Assert.Equal(ProjectType.Parse(TestingConstants.PROJECT_TYPE_ID), sut.ProjectType);
    }

  }  // ProjectTests

}  // namespace Empiria.Tests.Projects
