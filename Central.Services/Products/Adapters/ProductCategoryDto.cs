/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Output DTO                              *
*  Type     : ProductCategoryDto                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for ProductCategory instances.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products.Services.Adapters {

  /// <summary>Output DTO for ProductCategory instances.</summary>
  public class ProductCategoryDto {

    public string UID {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public string Description {
      get; internal set;
    }

    public NamedEntityDto ProductType {
      get; internal set;
    }

    public bool IsAssignable {
      get; internal set;
    }

    public FixedList<NamedEntityDto> ProductUnits {
      get; internal set;
    }

    public NamedEntityDto ParentCategory {
      get; internal set;
    }

    public NamedEntityDto Status {
      get; internal set;
    }

  }  // class ProductCategoryDto

}  // namespace Empiria.Products.Services.Adapters
