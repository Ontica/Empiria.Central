/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Static Services class                   *
*  Type     : ProductServices                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for Product instances.                                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Products.SATMexico;

using Empiria.Products.Services.Adapters;

namespace Empiria.Products.Services {

  /// <summary>Services for Product instances.</summary>
  static public class ProductServices {

    #region Services

    static public Product ActivateProduct(string productUID) {
      Assertion.Require(productUID, nameof(productUID));

      var product = Product.Parse(productUID);

      product.Activate();

      product.Save();

      return product;
    }


    static public Product CreateProduct(ProductFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Assertion.Require(fields.ProductCategoryUID, nameof(fields.ProductCategoryUID));
      Assertion.Require(fields.Name, nameof(fields.Name));

      var productCategory = ProductCategory.Parse(fields.ProductCategoryUID);

      var product = new Product(productCategory, fields.Name);

      product.Update(fields);

      product.Save();

      return product;
    }


    static public Product DeleteProduct(string productUID) {
      Assertion.Require(productUID, nameof(productUID));

      var product = Product.Parse(productUID);

      product.Delete();

      product.Save();

      return product;
    }


    static public FixedList<Product> SearchProducts(string keywords) {
      if (string.IsNullOrWhiteSpace(keywords)) {
        return new FixedList<Product>();
      }
      var query = new ProductsQuery {
         Keywords = keywords
      };


      string filter = query.MapToFilterString();

      string sort = query.MapToSortString();

      return ProductDataService.SearchProducts(filter, sort);
    }


    static public FixedList<SATProductoCucop> SearchCucopProducts(string keywords) {
      if (string.IsNullOrWhiteSpace(keywords)) {
        return new FixedList<SATProductoCucop>();
      }

      return SATDataItemDataService.SearchSATCucopProducts(keywords);
    }


    static public FixedList<Product> SearchProducts(ProductsQuery query) {
      Assertion.Require(query, nameof(query));

      string filter = query.MapToFilterString();

      string sort = query.MapToSortString();

      return ProductDataService.SearchProducts(filter, sort);
    }


    static public Product SuspendProduct(string productUID) {
      Assertion.Require(productUID, nameof(productUID));

      var product = Product.Parse(productUID);

      product.Suspend();

      product.Save();

      return product;
    }


    static public Product UpdateProduct(ProductFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var product = Product.Parse(fields.UID);

      product.Update(fields);

      product.Save();

      return product;
    }

    #endregion Services

  }  // class ProductServices

}  // namespace Empiria.Products.Services
