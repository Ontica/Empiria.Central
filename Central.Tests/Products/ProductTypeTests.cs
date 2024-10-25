/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ProductTypeTests                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for ProductType instances.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;

namespace Empiria.Tests.Products {

  /// <summary>Unit tests for ProductType instances.</summary>
  public class ProductTypeTests {


    [Fact]
    public void Should_Get_All_Product_Types() {
      var sut = ProductType.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_ProductType() {
      var sut = ProductType.Empty;

      Assert.NotNull(sut);
    }

  }  // class ProductTypeTests

}  // namespace Empiria.Tests.Products
