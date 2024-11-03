/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : DocumentProductTests                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for DocumentProduct instances.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;
using Empiria.Documents;

namespace Empiria.Tests.Documents {

  /// <summary>Unit tests for DocumentProduct instances.</summary>
  public class DocumentProductTests {

    [Fact]
    public void Should_Get_All_Document_Products() {
      var sut = BaseObject.GetFullList<DocumentProduct>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_DocumentProduct() {
      var sut = DocumentProduct.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.NotNull(sut.ProductType);
      //Assert.Equal(DocumentType.Empty, sut.ProductType);
      Assert.NotNull(sut.ProductCategory);
      Assert.Equal(ProductCategory.Empty, sut.ProductCategory);
      Assert.NotEmpty(sut.Name);
      Assert.NotNull(sut.InternalCode);
      Assert.NotNull(sut.Description);
      Assert.NotNull(sut.BaseUnit);
      Assert.Equal(ProductUnit.Empty, sut.BaseUnit);
      Assert.NotNull(sut.Manager);
      Assert.Empty(sut.ApplicationContentType);
      Assert.True(sut.FileType == Storage.FileType.Unknown);
    }


    [Fact]
    public void Should_Parse_All_Document_Products() {
      var products = BaseObject.GetFullList<DocumentProduct>("PRODUCT_ID <> -1");

      foreach (var sut in products) {
        Assert.NotNull(sut.ProductType);
        Assert.NotEqual(ProductType.Empty, sut.ProductType);
        Assert.NotNull(sut.ProductCategory);
        Assert.NotEqual(ProductCategory.Empty, sut.ProductCategory);
        Assert.NotEmpty(sut.Name);
        Assert.NotNull(sut.InternalCode);
        Assert.NotNull(sut.Description);
        Assert.NotNull(sut.BaseUnit);
        Assert.NotNull(sut.Manager);
        Assert.NotNull(sut.ApplicationContentType);
        Assert.True(sut.FileType != Storage.FileType.Unknown);
      }
    }

  }  // class DocumentProductTests

}  // namespace Empiria.Tests.Documents
