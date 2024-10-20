/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : ProductTests                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Product instances.                                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Xunit;

using Empiria.StateEnums;

using Empiria.Products;

namespace Empiria.Tests.Products {

  /// <summary>Unit tests for Product instances.</summary>
  public class ProductTests {

    [Fact]
    public void Should_Create_A_Product() {
      var productKind = ProductKind.Parse(TestingConstants.PRODUCT_KIND_UID);
      var name = "   A    new   product  ";

      var sut = new Product(productKind, name);

      Assert.Equal(productKind, sut.ProductKind);
      Assert.Equal(productKind.ProductType, sut.ProductType);
      Assert.Equal(EmpiriaString.Clean(name), sut.Name);
    }


    [Fact]
    public void Should_Delete_A_Product() {
      var sut = Product.Parse(TestingConstants.PRODUCT_UID);

      sut.Delete();

      Assert.Equal(EntityStatus.Deleted, sut.Status);
      Assert.Equal(DateTime.Today, sut.EndDate);
    }



    [Fact]
    public void Should_Get_All_Products() {
      var sut = BaseObject.GetFullList<Product>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_Product() {
      var sut = Product.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.NotNull(sut.ProductType);
      Assert.Equal(ProductType.Empty, sut.ProductType);
      Assert.NotNull(sut.ProductKind);
      Assert.Equal(ProductKind.Empty, sut.ProductKind);
      Assert.NotEmpty(sut.Name);
      Assert.NotNull(sut.InternalCode);
      Assert.NotNull(sut.Description);
      Assert.NotNull(sut.BaseUnit);
      Assert.Equal(ProductUnit.Empty, sut.BaseUnit);
      Assert.NotNull(sut.Manager);
    }


    [Fact]
    public void Should_Parse_All_Products() {
      var products = BaseObject.GetFullList<Product>("PRODUCT_ID <> -1");

      foreach (var sut in products) {
        Assert.NotNull(sut.ProductType);
        Assert.NotEqual(ProductType.Empty, sut.ProductType);
        Assert.NotNull(sut.ProductKind);
        Assert.NotEqual(ProductKind.Empty, sut.ProductKind);
        Assert.NotEmpty(sut.Name);
        Assert.NotNull(sut.InternalCode);
        Assert.NotNull(sut.Description);
        Assert.NotNull(sut.BaseUnit);
        Assert.NotNull(sut.Manager);
      }
    }


    [Fact]
    public void Should_Update_A_Product() {
      var sut = Product.Parse(TestingConstants.PRODUCT_UID);

      var fields = new ProductFields {
        Name = " The  new    name ",
        Description = " This  is  the   new description ",
      };

      sut.Update(fields);

      Assert.Equal(EmpiriaString.Clean(fields.Name), sut.Name);
      Assert.Equal(EmpiriaString.Clean(fields.Description), sut.Description);
    }

  }  // class ProductTests

}  // namespace Empiria.Tests.Products
