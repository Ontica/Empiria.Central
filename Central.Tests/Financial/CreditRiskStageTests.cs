/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : CreditRiskStageTests                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for CreditRiskStage type.                                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Financial;

namespace Empiria.Tests.Financial {

  /// <summary>Unit tests for CreditRiskStage type.</summary>
  public class CreditRiskStageTests {

    #region Facts

    [Fact]
    public void Should_Parse_All_Credit_Risk_Stages() {
      var creditStages = CreditRiskStage.GetList();

      foreach (var sut in creditStages) {
        Assert.NotEmpty(sut.Name);
      }
    }


    [Fact]
    public void Should_Read_All_Credit_Risk_Stages() {
      var sut = CreditRiskStage.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Read_Empty_CreditRiskStage() {
      var sut = CreditRiskStage.Empty;

      Assert.NotNull(sut);
      Assert.Equal("Empty", sut.UID);
      Assert.Equal(CreditRiskStage.Parse("Empty"), sut);
    }

    #endregion Facts

  }  // class CreditStageTests

}  // namespace Empiria.Tests.Financial
