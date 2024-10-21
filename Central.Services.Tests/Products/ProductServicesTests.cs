/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Project                                    Component : Test cases                              *
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

    #region Initialization

    private readonly ProductServices _services;

    public ProductServicesTests() {
      TestsCommonMethods.Authenticate();

      _services = ProductServices.ServiceInteractor();
    }

    ~ProductServicesTests() {
      _services.Dispose();
    }

    #endregion Initialization

    #region Facts

    [Fact]
    public void Should_Create_A_Product() {

      var fields = new ProductFields {
        ProductCategoryUID = TestingConstants.PRODUCT_CATEGORY_UID,
        Name = "Servicios de desarrollo de software"
      };

      ProductDto sut = _services.CreateProduct(fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Delete_A_Product() {
      var sut = _services.DeleteProduct(TestingConstants.PRODUCT_UID);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_A_Product() {
      var sut = _services.GetProduct(TestingConstants.PRODUCT_UID);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Search_Products() {
      var sut = _services.SearchProducts(string.Empty);

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

      var sut = _services.UpdateProduct(fields);

      Assert.NotNull(sut);
    }

    #endregion Facts

  }  // class ProductServicesTests

}  // namespace Empiria.Tests.Products.Services
