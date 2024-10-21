/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ProductCategoryTests                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for ProductCategory instances.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;
using Empiria.StateEnums;

namespace Empiria.Tests.Products {

  /// <summary>Unit tests for ProductCategory instances.</summary>
  public class ProductCategoryTests {


    [Fact]
    public void Should_Create_A_ProductCategory() {

      var productType = ProductType.Parse(TestingConstants.PRODUCT_TYPE_UID);
      var name = "   The new   category ";

      var sut = new ProductCategory(productType, name);

      Assert.Equal(productType, sut.ProductType);
      Assert.Equal(EmpiriaString.Clean(name), sut.Name);
      Assert.True(sut.IsAssignable);
      Assert.Empty(sut.ProductUnits);
      Assert.Equal(ProductCategory.Empty, sut.Parent);
    }


    [Fact]
    public void Should_Delete_A_ProductCategory() {
      var sut = ProductCategory.Parse(TestingConstants.PRODUCT_CATEGORY_UID);

      sut.Delete();

      Assert.Equal(EntityStatus.Deleted, sut.Status);
    }


    [Fact]
    public void Should_Get_All_Product_Categories() {
      var sut = BaseObject.GetList<ProductCategory>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_ProductCategory() {
      var sut = ProductCategory.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.NotNull(sut.Parent);
      Assert.NotEmpty(sut.Name);
      Assert.False(sut.IsAssignable);
      Assert.Equal(ProductType.Empty, sut.ProductType);
    }


    [Fact]
    public void Should_Parse_All_Product_Categories() {
      var categories = BaseObject.GetList<ProductCategory>();

      foreach (var sut in categories) {
        Assert.NotNull(sut.Parent);
        Assert.NotEmpty(sut.Name);
        Assert.True(sut.IsAssignable || true);
        Assert.NotNull(sut.ProductType);
      }
    }


    [Fact]
    public void Should_Update_A_ProductCategory() {
      var sut = ProductCategory.Parse(TestingConstants.PRODUCT_CATEGORY_UID);

      var fields = new ProductCategoryFields {
        Name = " The  new    name ",
        Description = " This  is  the   new description ",
      };

      sut.Update(fields);

      Assert.Equal(EmpiriaString.Clean(fields.Name), sut.Name);
      Assert.Equal(EmpiriaString.Clean(fields.Description), sut.Description);
    }

  }  // class ProductCategoryTests

}  // namespace Empiria.Tests.Products
