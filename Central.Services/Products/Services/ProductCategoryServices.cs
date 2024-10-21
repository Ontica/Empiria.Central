/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : ProductCategoryServices                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for ProductCategory instances.                                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Products.Services.Adapters;

namespace Empiria.Products.Services {

  /// <summary>Services for ProductCategory instances.</summary>
  public class ProductCategoryServices : Service {

    #region Constructors and parsers

    protected ProductCategoryServices() {
      // no-op
    }

    static public ProductCategoryServices ServiceInteractor() {
      return Service.CreateInstance<ProductCategoryServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public ProductCategoryDto CreateProductCategory(ProductCategoryFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Assertion.Require(fields.ProductTypeUID, nameof(fields.ProductTypeUID));
      Assertion.Require(fields.Name, nameof(fields.Name));

      var productType = ProductType.Parse(fields.ProductTypeUID);

      var category = new ProductCategory(productType, fields.Name);

      category.Update(fields);

      category.Save();

      return ProductCategoryMapper.Map(category);
    }


    public ProductCategoryDto DeleteProductCategory(string productCategoryUID) {
      Assertion.Require(productCategoryUID, nameof(productCategoryUID));

      var category = ProductCategory.Parse(productCategoryUID);

      category.Delete();

      category.Save();

      return ProductCategoryMapper.Map(category);
    }


    public ProductCategoryDto GetProductCategory(string productCategoryUID) {
      Assertion.Require(productCategoryUID, nameof(productCategoryUID));

      var category = ProductCategory.Parse(productCategoryUID);

      return ProductCategoryMapper.Map(category);
    }


    public FixedList<ProductCategoryDto> SearchProductCategories(string keywords) {

      FixedList<ProductCategory> categories = ProductCategory.GetList<ProductCategory>()
                                                             .ToFixedList();

      return ProductCategoryMapper.Map(categories);
    }


    public ProductCategoryDto UpdateProductCategory(ProductCategoryFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var category = ProductCategory.Parse(fields.UID);

      category.Update(fields);

      category.Save();

      return ProductCategoryMapper.Map(category);
    }

    #endregion Services

  }  // class ProductCategoryServices

}  // namespace Empiria.Products.Services
