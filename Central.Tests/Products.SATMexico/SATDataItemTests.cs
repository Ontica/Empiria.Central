/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Test cases                              *
*  Assembly : Empiria.Central.Core.Tests.dll             Pattern   : Unit tests                              *
*  Type     : SATDataItemTests                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for SATDataItem type.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products.SATMexico;

namespace Empiria.Tests.Products.SATMexico {

  /// <summary>Unit tests for SATDataItem type.</summary>
  public class SATDataItemTests {

    [Fact]
    public void Should_Clean_All_SAT_Data_Items() {
      var list = BaseObject.GetFullList<SATDataItem>();

      foreach (var sut in list) {
        sut.Save();
      }
    }


    [Fact]
    public void Should_Read_All_SAT_Data_Items() {
      var sut = BaseObject.GetFullList<SATDataItem>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }

  }  // class SATDataItemTests

}  // namespace Empiria.Tests.Products.SATMexico
