/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Project                                    Component : Test cases                              *
*  Assembly : Empiria.Central.Services.Tests.dll         Pattern   : Services tests                          *
*  Type     : ProjectServicesTests                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for project services.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Projects;
using Empiria.Projects.Services;
using Empiria.Projects.Services.Adapters;

namespace Empiria.Tests.Projects.Services {

  /// <summary>Test cases for project services.</summary>
  public class ProjectServicesTests {

    #region Initialization

    private readonly ProjectServices _services;

    public ProjectServicesTests() {
      TestsCommonMethods.Authenticate();

      _services = ProjectServices.ServiceInteractor();
    }

    ~ProjectServicesTests() {
      _services.Dispose();
    }

    #endregion Initialization

    #region Facts

    [Fact]
    public void Should_Create_A_Project() {

      var fields = new ProjectFields {
        Name = "Servicios de desarrollo de software 10001",
        Description = "Definicion del proyecto 10001",
        Code = "S2-2024-06-00001"
      };

      ProjectDto sut = _services.CreateProject(fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Read_All_Projects() {
      var sut = _services.GetProjectsList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }

    #endregion Facts

  }  // class ProjectServicesTests

}  // namespace Empiria.Tests.Projects.Services
