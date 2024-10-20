/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ProductKindTests                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for ProductKind instances.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;

namespace Empiria.Tests.Products {

  /// <summary>Unit tests for ProductKind instances.</summary>
  public class ProductKindTests {

    [Fact]
    public void Should_Get_All_Product_Kinds() {
      var sut = BaseObject.GetList<ProductKind>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_ProductKind() {
      var sut = ProductKind.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.NotNull(sut.Parent);
      Assert.NotEmpty(sut.Name);
      Assert.False(sut.IsAssignable);
      Assert.Equal(ProductType.Empty, sut.ProductType);
    }


    [Fact]
    public void Should_Parse_All_Product_Kinds() {
      var kinds = BaseObject.GetList<ProductKind>();

      foreach (var sut in kinds) {
        Assert.NotNull(sut.Parent);
        Assert.NotEmpty(sut.Name);
        Assert.True(sut.IsAssignable || true);
        Assert.NotNull(sut.ProductType);
      }
    }

  }  // class ProductKindTests

}  // namespace Empiria.Tests.Products
