/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Input Fields DTO                        *
*  Type     : ProductCategoryFields                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input fields DTO used to create and update ProductCategory instances.                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products {

  /// <summary>Input fields DTO used to create and update ProductCategory instances.</summary>
  public class ProductCategoryFields : NamedEntityFields {

    public string ProductTypeUID {
      get; set;
    } = string.Empty;


    public string Description {
      get; set;
    } = string.Empty;


    public string[] ProductUnits {
      get; set;
    } = new string[0];


    public bool? IsAssignable {
      get; set;
    }


    public string ParentCategoryUID {
      get; set;
    } = string.Empty;

  }  // class ProductCategoryFields



  /// <summary>Extension methods for ProductCategoryFields.</summary>
  public static class ProductCategoryFieldsExtensions {

    static internal void EnsureValid(this ProductCategoryFields fields) {

      fields.Name = EmpiriaString.Clean(fields.Name);
      fields.Description = EmpiriaString.Clean(fields.Description);

      if (fields.ProductTypeUID.Length != 0) {
        _ = ProductType.Parse(fields.ProductTypeUID);
      }

      if (fields.ParentCategoryUID.Length != 0) {
        _ = ProductCategory.Parse(fields.ParentCategoryUID);
      }

      foreach (var productUnitUID in fields.ProductUnits) {
         _ = ProductUnit.Parse(productUnitUID);
      }

    }

  }  // class ProductCategoryFieldsExtensions

}  // namespace Empiria.Products
