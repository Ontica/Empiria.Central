/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Input Fields DTO                        *
*  Type     : ProductFields                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input fields DTO used to create and update Product instances.                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.Products {

  /// <summary>Input fields DTO used to create and update Product instances.</summary>
  public class ProductFields : NamedEntityFields {

    public string ProductCategoryUID {
      get; set;
    } = string.Empty;


    public string Description {
      get; set;
    } = string.Empty;


    public string InternalCode {
      get; set;
    } = string.Empty;


    public string[] Identificators {
      get; set;
    } = new string[0];


    public string[] Roles {
      get; set;
    } = new string[0];


    public string[] Tags {
      get; set;
    } = new string[0];


    public string BaseUnitUID {
      get; set;
    } = string.Empty;


    public string ManagerUID {
      get; set;
    } = string.Empty;

  }  // class ProductFields


  /// <summary>Extension methods for ProductFields.</summary>
  public static class ProductFieldsExtensions {

    static internal void EnsureValid(this ProductFields fields) {
      fields.Name = EmpiriaString.Clean(fields.Name);
      fields.Description = EmpiriaString.Clean(fields.Description);
      fields.InternalCode = EmpiriaString.Clean(fields.InternalCode);

      if (fields.ProductCategoryUID.Length != 0) {
        _ = ProductCategory.Parse(fields.ProductCategoryUID);
      }
      if (fields.BaseUnitUID.Length != 0) {
        _ = ProductUnit.Parse(fields.BaseUnitUID);
      }
      if (fields.ManagerUID.Length != 0) {
        _ = Party.Parse(fields.ManagerUID);
      }
    }

  }  // class ProductFieldsExtensions

}  // namespace Empiria.Products
