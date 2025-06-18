/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Mapper                                  *
*  Type     : OrganizationalStructureMapper              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Mapping services for organizational structure.                                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;
using Empiria.Parties.Adapters;

namespace Empiria.HumanResources.Adapters {

  /// <summary>Mapping services for organizational structure.</summary>
  static public class OrganizationalStructureMapper {

    static internal OrganizationalStructureHolder Map(OrganizationalUnit orgUnit) {

      return new OrganizationalStructureHolder {
        OrganizationalUnit = OrganizationalUnitMapper.Map(orgUnit),
        Accountabilities = AccountabilityMapper.Map(orgUnit),
      };
    }

  }  // class OrganizationalStructureMapper

}  // namespace Empiria.HumanResources.Adapters
