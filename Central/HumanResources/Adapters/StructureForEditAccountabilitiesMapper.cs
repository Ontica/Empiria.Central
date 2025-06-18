/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Structurer mapper                       *
*  Type     : StructureForEditAccountabilitiesMapper     License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Maps structured data for use in accountabilities edition.                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.HumanResources.Adapters {

  /// <summary>Maps structured data for use in accountabilities edition.</summary>
  static internal class StructureForEditAccountabilitiesMapper {

    static private FixedList<PartyRole> _allRoles = PartyRole.GetList();

    static internal StructureForEditAccountabilities Map(Party commissioner) {
      Assertion.Require(commissioner, nameof(commissioner));

      var structurer = new Structurer(commissioner);

      return structurer.MapAccountabilities();
    }


    private class Structurer {

      private Party _commissioner;
      private FixedList<PartyRole> _commissionerRoles;

      internal Structurer(Party commissioner) {
        _commissioner = commissioner;
        _commissionerRoles =_allRoles.FindAll(x => x.AppliesTo.Intersect(_commissioner.Roles).Count != 0);
      }


      internal StructureForEditAccountabilities MapAccountabilities() {
        FixedList<PartyRelationCategory> categories = _commissionerRoles.SelectDistinct(x => x.Category);

        return new StructureForEditAccountabilities {
          UID = _commissioner.UID,
          Name = _commissioner.Name,
          PartyRelationCategories = categories.Select(x => MapPartyRelationCategory(x))
                                              .ToFixedList(),
        };
      }


      private PartyRelationCategoryDto MapPartyRelationCategory(PartyRelationCategory category) {
        var categoryRoles = _commissionerRoles.FindAll(x => x.Category.Equals(category));

        return new PartyRelationCategoryDto {
          UID = category.UID,
          Name = category.Name,
          Roles = categoryRoles.Select(x => MapPartyRole(x))
                               .ToFixedList()
        };
      }


      private PartyRoleDto MapPartyRole(PartyRole role) {
        return new PartyRoleDto {
           UID = role.UID,
           Name = role.Name,
           RequiresCode = role.RequiresCode,
        };
      }

    }  // class Structurer

  }  // class StructureForEditAccountabilitiesMapper

}  // namespace Empiria.HumanResources.Adapters
