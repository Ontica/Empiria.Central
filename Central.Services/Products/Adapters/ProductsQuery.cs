/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Payments.Core.dll                  Pattern   : Query Data Transfer Object              *
*  Type     : ProductsQuery                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Query DTO used to search Product objects.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.StateEnums;

namespace Empiria.Products.Services.Adapters {

  /// <summary>Query DTO used to search Product objects.</summary>
  public class ProductsQuery {

    public string ProductTypeUID {
      get; set;
    } = string.Empty;


    public string ProductCategoryUID {
      get; set;
    } = string.Empty;


    public string Keywords {
      get; set;
    } = string.Empty;


    public string InternalCode {
      get; set;
    } = string.Empty;


    public string[] Tags {
      get; set;
    } = new string[0];


    public string ManagerUID {
      get; set;
    } = string.Empty;


    public EntityStatus Status {
      get; set;
    } = EntityStatus.All;


    public string OrderBy {
      get; set;
    } = string.Empty;

  }  // class ProductsQuery

}  // namespace Empiria.Products.Services.Adapters
