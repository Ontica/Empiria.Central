/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Mapper                                  *
*  Type     : ProductMapper                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides mapping services for Product instances.                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.StateEnums;

namespace Empiria.Products.Services.Adapters {

  /// <summary>Provides mapping services for Product instances.</summary>
  static internal class ProductMapper {

    static internal FixedList<ProductDto> Map(FixedList<Product> products) {
      return products.Select(x => Map(x))
                     .ToFixedList();
    }


    static internal ProductDto Map(Product product) {
      return new ProductDto {
        UID = product.UID,
        Name = product.Name,
        Description = product.Description,
        InternalCode = product.InternalCode,
        Tags = product.Tags,
        BaseUnit = product.BaseUnit.MapToNamedEntity(),
        Manager = product.Manager.MapToNamedEntity(),
        ProductCategory = product.ProductCategory.MapToNamedEntity(),
        ProductType = product.ProductType.MapToNamedEntity(),
        StartDate = product.StartDate,
        EndDate = product.EndDate,
        Status = product.Status.MapToDto()
      };
    }

  }  // class ProductMapper

} // namespace Empiria.Products.Services.Adapters
