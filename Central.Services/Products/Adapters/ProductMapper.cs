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
  static public class ProductMapper {

    static internal FixedList<ProductDto> Map(FixedList<Product> products) {
      return products.Select(x => Map(x))
                     .ToFixedList();
    }


    static public ProductDto Map(Product product) {
      return new ProductDto {
        UID = product.UID,
        Name = product.Name,
        Description = product.Description,
        InternalCode = product.InternalCode,
        Identificators = product.Identificators,
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


    static internal FixedList<ProductDescriptorDto> MapToDescriptor(FixedList<Product> products) {
      return products.Select(x => MapToDescriptor(x))
                     .ToFixedList();
    }


    static internal FixedList<ProductSearchDto> MapToSearchDescriptor(FixedList<Product> products) {
      return products.Select(x => MapToSearchDescriptor(x))
                     .ToFixedList();
    }


    #region Helpers

    static private ProductDescriptorDto MapToDescriptor(Product product) {
      return new ProductDescriptorDto {
        UID = product.UID,
        Name = product.Name,
        Description = product.Description,
        InternalCode = product.InternalCode,
        BaseUnitName = product.BaseUnit.Name,
        ManagerName = product.Manager.Name,
        ProductCategoryName = product.ProductCategory.Name,
        ProductTypeName = product.ProductType.DisplayName,
        StartDate = product.StartDate,
        EndDate = product.EndDate,
        StatusName = product.Status.GetName()
      };
    }


    static private ProductSearchDto MapToSearchDescriptor(Product product) {
      return new ProductSearchDto {
        UID = product.UID,
        Name = product.Name,
        Description = product.Description,
        InternalCode = product.InternalCode,
        BaseUnit = product.BaseUnit.MapToNamedEntity(),
        ManagerName = product.Manager.Name,
        ProductCategoryName = product.ProductCategory.Name,
        ProductTypeName = product.ProductType.DisplayName
      };
    }

    #endregion Helpers

  }  // class ProductMapper

} // namespace Empiria.Products.Services.Adapters
