/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ProjectTypeTests                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for ProjectType type.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Projects;

namespace Empiria.Tests.Projects {

  /// <summary>Unit tests for Project type.</summary>
  public class ProjectTypeTests {

    [Fact]
    public void Should_Get_All_ProjectTypes() {
      var sut = ProjectType.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_All_ProjectType_Projects() {
      var projectTypes = ProjectType.GetList();

      foreach (var projectType in projectTypes) {
        var sut = projectType.GetProjects();

        Assert.NotNull(sut);
      }
    }


    [Fact]
    public void Should_Get_Empty_ProjectType() {
      var sut = ProjectType.Empty;

      Assert.NotNull(sut);
      Assert.Empty(sut.GetProjects());
    }

  }  // ProjectTypeTests

}  // namespace Empiria.Tests.Projects
