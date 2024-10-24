/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Query Data Transfer Object              *
*  Type     : ProductsQuery                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Query DTO used to search Product objects.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;
using Empiria.StateEnums;

namespace Empiria.Products.Services.Adapters {

  /// <summary>Extension methods for ProductsQuery interface adapter.</summary>
  static internal class ProductsQueryExtensions {

    #region Extension methods

    static internal void EnsureIsValid(this ProductsQuery query) {
      // no-op
    }


    static internal string MapToFilterString(this ProductsQuery query) {
      string internalCodeFilter = BuildInternalCodeFilter(query.InternalCode);
      string productTypeFilter = BuildProductTypeFilter(query.ProductTypeUID);
      string productCategoryFilter = BuildProductCategoryFilter(query.ProductCategoryUID);
      string managerFilter = BuildManagerFilter(query.ManagerUID);
      string tagsFilter = BuildTagsFilter(query.Tags);
      string keywordsFilter = BuildKeywordsFilter(query.Keywords);
      string statusFilter = BuildStatusFilter(query.Status);

      var filter = new Filter(internalCodeFilter);

      filter.AppendAnd(productTypeFilter);
      filter.AppendAnd(productCategoryFilter);
      filter.AppendAnd(managerFilter);
      filter.AppendAnd(tagsFilter);
      filter.AppendAnd(keywordsFilter);
      filter.AppendAnd(statusFilter);

      return filter.ToString();
    }


    static internal string MapToSortString(this ProductsQuery query) {
      if (query.OrderBy.Length != 0) {
        return query.OrderBy;
      } else {
        return "PRODUCT_NAME, PRODUCT_INTERNAL_CODE";
      }
    }

    #endregion Extension methods

    #region Helpers

    static private string BuildInternalCodeFilter(string internalCode) {
      if (internalCode.Length == 0) {
        return string.Empty;
      }

      return SearchExpression.ParseLike("PRODUCT_INTERNAL_CODE",
                                        internalCode.ToUpperInvariant());
    }


    static private string BuildKeywordsFilter(string keywords) {
      if (keywords.Length == 0) {
        return string.Empty;
      }
      return SearchExpression.ParseAndLikeKeywords("PRODUCT_KEYWORDS", keywords);
    }


    static private string BuildManagerFilter(string managerUID) {
      if (managerUID.Length == 0) {
        return string.Empty;
      }

      var manager = Party.Parse(managerUID);

      return $"PRODUCT_MANAGER_ID = {manager.Id}";
    }


    static private string BuildProductCategoryFilter(string productCategoryUID) {
      if (productCategoryUID.Length == 0) {
        return string.Empty;
      }

      var category = ProductCategory.Parse(productCategoryUID);

      return $"PRODUCT_CATEGORY_ID = {category.Id}";
    }


    static private string BuildProductTypeFilter(string productTypeUID) {
      if (productTypeUID.Length == 0) {
        return string.Empty;
      }

      var productType = ProductCategory.Parse(productTypeUID);

      return $"PRODUCT_TYPE_ID = {productType.Id}";
    }


    static private string BuildStatusFilter(EntityStatus status) {
      if (status == EntityStatus.All) {
        return "PRODUCT_STATUS <> 'X' ";
      }

      return $"PRODUCT_STATUS = '{(char) status}'";
    }


    static private string BuildTagsFilter(string[] tags) {
      if (tags.Length == 0) {
        return string.Empty;
      }

      var filter = SearchExpression.ParseOrLikeKeywords("PRODUCT_TAGS", string.Join(" ", tags));

      return $"({filter})";
    }

    #endregion Helpers

  }  // class ProductsQueryExtensions

}  // namespace Empiria.Products.Services.Adapters
