﻿/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ProductUnitTests                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for ProductUnit instances.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;

namespace Empiria.Tests.Products {

  /// <summary>Unit tests for ProductUnit instances.</summary>
  public class ProductUnitTests {

    [Fact]
    public void Should_Get_All_Product_Units() {
      var sut = BaseObject.GetList<ProductUnit>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_ProductUnit() {
      var sut = ProductUnit.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.NotNull(sut.Abbreviation);
      Assert.NotNull(sut.Name);
      Assert.NotNull(sut.SATCodes);
    }


    [Fact]
    public void Should_Parse_All_Product_Units() {
      var units = BaseObject.GetList<ProductUnit>();

      foreach (var sut in units) {
        Assert.NotNull(sut.Abbreviation);
        Assert.NotEmpty(sut.Name);
        Assert.NotNull(sut.SATCodes);
        Assert.NotEmpty(sut.SATCodes);
      }
    }

  }  // class ProductUnitTests

}  // namespace Empiria.Tests.Products
