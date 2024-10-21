/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Test cases                              *
*  Assembly : Empiria.Central.Core.Tests.dll             Pattern   : Unit tests                              *
*  Type     : SATProductoTests                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for SATProducto instances.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products.SATMexico;

namespace Empiria.Tests.Products.SATMexico {

  /// <summary>Unit tests for SATProducto instances.</summary>
  public class SATProductoTests {

    [Fact]
    public void Should_Read_All_SATProducto_Instances() {
      var sut = SATProducto.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Read_Empty_SATProducto() {
      var sut = SATProducto.Empty;

      Assert.NotNull(sut);
    }

  }  // class SATProductoTests

}  // namespace Empiria.Tests.Products.SATMexico
