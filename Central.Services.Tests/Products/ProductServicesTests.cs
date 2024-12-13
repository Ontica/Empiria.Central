/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Services.Tests.dll         Pattern   : Services tests                          *
*  Type     : ProductServicesTests                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for product services.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;
using Empiria.Products.Services;
using Empiria.Products.Services.Adapters;

namespace Empiria.Tests.Products.Services {

  /// <summary>Test cases for product services.</summary>
  public class ProductServicesTests {

    #region Facts

    [Fact]
    public void Should_Create_A_Product() {

      var fields = new ProductFields {
        ProductCategoryUID = TestingConstants.PRODUCT_CATEGORY_UID,
        Name = "Servicios de auditoría administrativa"
      };

      Product sut = ProductServices.CreateProduct(fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Delete_A_Product() {
      var sut = ProductServices.DeleteProduct(TestingConstants.PRODUCT_UID);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Search_Products() {
      var query = new ProductsQuery {
        Keywords = "Servicio"
      };

      var sut = ProductServices.SearchProducts(query);

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Update_A_Product() {
      var fields = new ProductFields {
        UID = TestingConstants.PRODUCT_UID,
        ProductCategoryUID = TestingConstants.PRODUCT_CATEGORY_UID,
        Name = "Servicios de desarrollo de software II"
      };

      var sut = ProductServices.UpdateProduct(fields);

      Assert.NotNull(sut);
    }

    #endregion Facts

  }  // class ProductServicesTests

}  // namespace Empiria.Tests.Products.Services
