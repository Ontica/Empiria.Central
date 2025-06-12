/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Input Query DTO                         *
*  Type     : OrganizationalStructureServices            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input query DTO used to retrieve organizational structures.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.HumanResources.Adapters {

  /// <summary>Input query DTO used to retrieve organizational structures.</summary>
  public class OrganizationalStructureQuery {

    public string Keywords {
      get; set;
    } = string.Empty;

  }  // // class OrganizationalStructureQuery

}  // namespace Empiria.HumanResources.Adapters
