/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Output DTO                              *
*  Type     : StructureForEditAccountabilities           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for use in accountabilities edition.                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.HumanResources.Adapters {

  /// <summary>Output DTO for use in accountabilities edition.</summary>
  public class StructureForEditAccountabilities {

    public string UID {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public FixedList<PartyRelationCategoryDto> PartyRelationCategories {
      get; internal set;
    }

  }  // class StructureForEditAccountabilities



  /// <summary>Output DTO for a PartyRelationCategory with its roles.</summary>
  public class PartyRelationCategoryDto {

    public string UID {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public FixedList<PartyRoleDto> Roles {
      get; internal set;
    }

  }  // class PartyRelationCategoryDto



  /// <summary>Output DTO for a PartyRole.</summary>
  public class PartyRoleDto {

    public string UID {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public bool RequiresCode {
      get; internal set;
    }

  }  // class PartyRoleDto

}  // namespace Empiria.HumanResources.Adapters
