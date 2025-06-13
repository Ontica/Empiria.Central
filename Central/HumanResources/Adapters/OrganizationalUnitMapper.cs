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

    static internal OrganizationalStructureHolder Map(OrganizationalUnit orgUnit) {
      return new OrganizationalStructureHolder {
        OrganizationalUnit = MapToHolder(orgUnit),
        Accountabilities = AccountabilityMapper.Map(orgUnit),
      };
    }

    static internal FixedList<OrganizationalUnitDescriptor> Map(FixedList<OrganizationalUnit> orgUnits) {
      return orgUnits.Select(x => MapToDescriptor(x))
                     .ToFixedList();

    }


    static private OrganizationalUnitDto MapToHolder(OrganizationalUnit orgUnit) {
      return new OrganizationalUnitDto {
         UID = orgUnit.UID,
         Code = orgUnit.Code,
         Name = orgUnit.Name,
         Type = orgUnit.PartyType.MapToNamedEntity(),
         Parent = orgUnit.Parent.MapToNamedEntity(),
         Responsible = Person.Empty.MapToNamedEntity(),
         StartDate = ExecutionServer.DateMinValue,
         EndDate = ExecutionServer.DateMaxValue,
      };
    }


    static private OrganizationalUnitDescriptor MapToDescriptor(OrganizationalUnit orgUnit) {
      return new OrganizationalUnitDescriptor {
        UID = orgUnit.UID,
        Code = orgUnit.Code,
        Name = orgUnit.Name,
        FullName = orgUnit.FullName,
        TypeName = orgUnit.PartyType.DisplayName,
        ParentName = orgUnit.Parent.FullName,
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
