/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Input Query DTO                         *
*  Type     : CommissionerResponsiblesQuery              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input query DTO used to retrieve commissioner's responsibles.                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.HumanResources.Adapters {

  /// <summary>Input query DTO used to retrieve commissioner's responsibles.</summary>
  public class CommissionerResponsiblesQuery {

    public string CommissionerUID {
      get; set;
    } = string.Empty;


    public string PartyRoleUID {
      get; set;
    } = string.Empty;


    public string Keywords {
      get; set;
    } = string.Empty;


  }  // // class CommissionerResponsiblesQuery

}  // namespace Empiria.HumanResources.Adapters
