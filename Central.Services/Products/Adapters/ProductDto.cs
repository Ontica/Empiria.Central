/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Output DTO                              *
*  Type     : ProductDto                                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for Product instances.                                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.Products.Services.Adapters {

  /// <summary>Output DTO for Product instances.</summary>
  public class ProductDto : INamedEntity {

    public string UID {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public string Description {
      get; internal set;
    }

    public string InternalCode {
      get; internal set;
    }

    public FixedList<string> Tags {
      get; internal set;
    }

    public NamedEntityDto BaseUnit {
      get; internal set;
    }

    public NamedEntityDto Manager {
      get; internal set;
    }

    public NamedEntityDto ProductCategory {
      get; internal set;
    }

    public NamedEntityDto ProductType {
      get; internal set;
    }

    public DateTime StartDate {
      get; internal set;
    }

    public DateTime EndDate {
      get; internal set;
    }

    public NamedEntityDto Status {
      get; internal set;
    }

  }  // class ProductDto

}  // namespace Empiria.Products.Services.Adapters
