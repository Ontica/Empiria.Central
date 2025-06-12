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
using Empiria.StateEnums;

namespace Empiria.HumanResources {

  /// <summary>Mapping services for organizational structure.</summary>
  static public class OrganizationalUnitMapper {

    static internal FixedList<OrganizationalUnitDescriptor> Map(FixedList<OrganizationalUnit> orgUnits) {
      return orgUnits.Select(x => Map(x))
                     .ToFixedList();

    }

    static private OrganizationalUnitDescriptor Map(OrganizationalUnit orgUnit) {
      return new OrganizationalUnitDescriptor {
        UID = orgUnit.UID,
        Code = orgUnit.Code,
        Name = orgUnit.Name,
        FullName = orgUnit.FullName,
        TypeName = orgUnit.PartyType.DisplayName,
        ResponsibleName = "No determinado",
        Level = 1,
        IsLastLevel = true,
        StartDate = ExecutionServer.DateMinValue,
        EndDate = ExecutionServer.DateMaxValue,
        Obsolete = false,
        StatusName = orgUnit.Status.GetName(),
      };
    }

  }  // class OrganizationalStructureMapper

}  // namespace Empiria.HumanResources
