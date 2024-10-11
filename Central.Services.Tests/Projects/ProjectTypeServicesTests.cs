/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Services.Tests.dll         Pattern   : Services tests                          *
*  Type     : ProjectTypeServicesTests                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for project type services.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Projects;
using Empiria.Projects.Services;

namespace Empiria.Tests.Central.Projects.Services {

  /// <summary>Test cases for project type services.</summary>
  public class ProjectTypeServicesTests {

    #region Initialization

    private readonly ProjectTypeServices _services;


    public ProjectTypeServicesTests() {
      TestsCommonMethods.Authenticate();

      _services = ProjectTypeServices.ServiceInteractor();
    }

    ~ProjectTypeServicesTests() {
      _services.Dispose();
    }

    #endregion Use cases initialization

    #region Facts

    [Fact]
    public void Should_Create_A_Project_Type() {

      var fields = new NamedEntityFields {
        Name = "Servicios de desarrollo de software 1000",
      };

      NamedEntityDto sut = _services.CreateProjectType(fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Delete_A_Project_Type() {

      _services.DeleteProjectType("63e0d06b-fd6c-43cc-b35f-7cb569dadcb9");

      var sut = ProjectType.Parse("63e0d06b-fd6c-43cc-b35f-7cb569dadcb9");

      Assert.True(sut.Status == StateEnums.EntityStatus.Deleted);
    }


    [Fact]
    public void Should_Read_All_Project_Types() {
      var sut = _services.GetProjectTypes();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Update_A_Project_Type() {

      var fields = new NamedEntityFields {
        UID = "63e0d06b-fd6c-43cc-b35f-7cb569dadcb9",
        Name = "10001 - Servicios de desarrollo de software 10001"
      };

      NamedEntityDto sut = _services.UpdateProjectType(fields);

      Assert.NotNull(sut);
    }

    #endregion Facts

  }  // class ProjectTypeServicesTests

}  // namespace Empiria.Tests.Central.Projects.Services
