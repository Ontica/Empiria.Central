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

namespace Empiria.Tests.Projects {

  /// <summary>Unit tests for Project type.</summary>
  public class ProjectTests {

    [Fact]
    public void Should_Get_All_Projects() {
      var sut = Project.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


  }  // ProjectTests

}  // namespace Empiria.Tests.Projects
