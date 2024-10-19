/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ProductTests                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Product instances.                                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;

namespace Empiria.Tests.Products {

  /// <summary>Unit tests for Product instances.</summary>
  public class ProductTests {

    [Fact]
    public void Should_Get_All_Products() {
      var sut = BaseObject.GetList<Product>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_Product() {
      var sut = Product.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
    }

  }  // class ProductTests

}  // namespace Empiria.Tests
