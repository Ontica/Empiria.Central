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

namespace Empiria.HumanResources.Adapters {

  /// <summary>Output DTO with acountability data.</summary>
  public class AccountabilityDto {

    public string UID {
      get; internal set;
    }

    [Newtonsoft.Json.JsonProperty(PropertyName = "PartyRelationType")]
    public NamedEntityDto PartyRelationCategory {
      get; internal set;
    }

    public NamedEntityDto Responsible {
      get; internal set;
    }

    public NamedEntityDto Role {
      get; internal set;
    }

    public NamedEntityDto Commissioner {
      get; internal set;
    }

    public string Code {
      get; internal set;

    }
    public string Description {
      get; internal set;
    }

    public FixedList<string> Tags {
      get; internal set;
    }

    public DateTime StartDate {
      get; internal set;
    }

    public DateTime EndDate {
      get; internal set;
    }

  }  // class AccountabilityDto



  /// <summary>Output DTO with acountability data for use in lists.</summary>
  public class AccountabilityDescriptor {

    public string UID {
      get; internal set;
    }

    public string PartyRelationCategoryName {
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

    public string Code {
      get; internal set;
    }

    public string Description {
      get; internal set;
    }

    public DateTime StartDate {
      get; internal set;
    }

    public DateTime EndDate {
      get; internal set;
    }

  }  // class AccountabilityDescriptor

}  // namespace Empiria.HumanResources.Adapters
