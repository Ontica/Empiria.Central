/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : InterestRateTypeTests                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for InterestRateType type.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Financial;

namespace Empiria.Tests.Financial {

  /// <summary>Unit tests for InterestRateType type.</summary>
  public class InterestRateTypeTests {

    #region Facts

    [Fact]
    public void Should_Parse_All_Interest_Rate_Types() {
      var list = InterestRateType.GetList();

      foreach (var sut in list) {
        Assert.NotEmpty(sut.Code);
        Assert.NotEmpty(sut.Name);
      }
    }

    [Fact]
    public void Should_Read_All_Interest_Rate_Types() {
      var sut = InterestRateType.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Read_Empty_InterestRateType() {
      var sut = InterestRateType.Empty;

      Assert.NotNull(sut);
      Assert.Equal("Empty", sut.UID);
      Assert.Equal(InterestRateType.Parse("Empty"), sut);
    }

    #endregion Facts

  }  // class InterestRateTypeTests

}  // namespace Empiria.Tests.Financial
