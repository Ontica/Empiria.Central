/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ReportTypeTests                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for ReportType type.                                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Documents;
using Empiria.Documents.UseCases;

namespace Empiria.Tests.Documents {

  /// <summary>Unit tests for ReportType type.</summary>
  public class ReportTypeTests {

    [Fact]
    public void Should_Get_All_ReportTypes_UseCase() {

      TestsCommonMethods.Authenticate();

      using (var useCase = ReportTypesUseCases.UseCaseInteractor()) {

        var sut = useCase.GetReportTypes();

        Assert.NotNull(sut);
        Assert.NotEmpty(sut);
      }
    }


    [Fact]
    public void Should_Get_All_ReportTypes() {
      var sut = ReportType.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }

  }  // class ReportTypeTests

}  // namespace Empiria.Tests.Documents
