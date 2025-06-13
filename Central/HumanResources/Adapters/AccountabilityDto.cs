/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Output DTO                              *
*  Type     : AccountabilityDto                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for accountability data.                                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.HumanResources {

  /// <summary>Output DTO with acountability data for use in lists.</summary>
  public class AccountabilityDescriptor {

    public string UID {
      get; internal set;
    }

    public string ResponsibleName {
      get; internal set;
    }

    public string RoleName {
      get; internal set;
    }

    public string CommissionerName {
      get; internal set;
    }

    public DateTime StartDate {
      get; internal set;
    }

    public DateTime EndDate {
      get; internal set;
    }

  }  // class AccountabilityDescriptor

}  // namespace Empiria.HumanResources
