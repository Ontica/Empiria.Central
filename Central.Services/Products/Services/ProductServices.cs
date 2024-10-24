/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : ProductServices                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for Product instances.                                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Products.Services.Adapters;

namespace Empiria.Products.Services {

  /// <summary>Services for Product instances.</summary>
  public class ProductServices : Service {

    #region Constructors and parsers

    protected ProductServices() {
      // no-op
    }

    static public ProductServices ServiceInteractor() {
      return Service.CreateInstance<ProductServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public ProductDto CreateProduct(ProductFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Assertion.Require(fields.ProductCategoryUID, nameof(fields.ProductCategoryUID));
      Assertion.Require(fields.Name, nameof(fields.Name));

      var productCategory = ProductCategory.Parse(fields.ProductCategoryUID);

      var product = new Product(productCategory, fields.Name);

      product.Update(fields);

      product.Save();

      return ProductMapper.Map(product);
    }


    public ProductDto DeleteProduct(string productUID) {
      Assertion.Require(productUID, nameof(productUID));

      var product = Product.Parse(productUID);

      product.Delete();

      product.Save();

      return ProductMapper.Map(product);
    }


    public ProductDto GetProduct(string productUID) {
      Assertion.Require(productUID, nameof(productUID));

      var product = Product.Parse(productUID);

      return ProductMapper.Map(product);
    }


    public FixedList<ProductDto> SearchProducts(ProductsQuery query) {
      Assertion.Require(query, nameof(query));

      string filter = query.MapToFilterString();

      string sort = query.MapToSortString();

      FixedList<Product> products = ProductDataService.SearchProducts(filter, sort);

      return ProductMapper.Map(products);
    }

    public ProductDto UpdateProduct(ProductFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var product = Product.Parse(fields.UID);

      product.Update(fields);

      product.Save();

      return ProductMapper.Map(product);
    }

    #endregion Services

  }  // class ProductServices

}  // namespace Empiria.Products.Services
