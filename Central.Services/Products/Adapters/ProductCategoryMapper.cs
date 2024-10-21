/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Mapper                                  *
*  Type     : ProductCategoryMapper                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides mapping services for ProductCategory instances.                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.StateEnums;

namespace Empiria.Products.Services.Adapters {

  /// <summary>Provides mapping services for ProductCategory instances.</summary>
  static internal class ProductCategoryMapper {

    static internal FixedList<ProductCategoryDto> Map(FixedList<ProductCategory> categories) {
      return categories.Select(x => Map(x))
                       .ToFixedList();
    }


    static internal ProductCategoryDto Map(ProductCategory category) {
      return new ProductCategoryDto {
        UID = category.UID,
        Name = category.Name,
        Description = category.Description,
        ProductType = category.ProductType.MapToNamedEntity(),
        IsAssignable = category.IsAssignable,
        ProductUnits = category.ProductUnits.MapToNamedEntityList(),
        ParentCategory = category.Parent.MapToNamedEntity(),
        Status = category.Status.MapToDto()
      };
    }

  }  // class ProductCategoryMapper

} // namespace Empiria.Products.Services.Adapters
