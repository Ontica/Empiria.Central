/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Output DTO                              *
*  Type     : OrganizationalStructureHolder              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for an organizational unit with accountabilities.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties.Adapters;

namespace Empiria.HumanResources.Adapters {

  /// <summary>Output DTO for an organizational unit with accountabilities.</summary>
  public class OrganizationalStructureHolder {

    public OrganizationalUnitDto OrganizationalUnit {
      get; internal set;
    }

    public FixedList<AccountabilityDescriptor> Accountabilities {
      get; internal set;
    }

    public BaseActions Actions {
      get; internal set;
    }

  } // class OrganizationalStructureHolder

}  // namespace Empiria.HumanResources.Adapters
