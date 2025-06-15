/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : String query builder                    *
*  Type     : OrganizationalStructureQueryBuilder        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : String query builder for OrganizationalStructureQuery.                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;
using Empiria.StateEnums;

namespace Empiria.HumanResources.Adapters {

  /// <summary>String query builder for OrganizationalStructureQuery.</summary>
  static internal class OrganizationalStructureQueryBuilder {

    #region Extension methods

    static internal string MapToFilterString(this OrganizationalStructureQuery query) {
      string orgUnitTypeFilter = BuildOrgUnitTypeFilter();
      string statusFilter = BuildStatusFilter(query.Status);
      string keywordsFilter = BuildKeywordsFilter(query.Keywords);

      var filter = new Filter(orgUnitTypeFilter);

      filter.AppendAnd(statusFilter);
      filter.AppendAnd(keywordsFilter);

      return filter.ToString();
    }


    static internal string MapToSortString(this OrganizationalStructureQuery query) {
      if (query.OrderBy.Length != 0) {
        return query.OrderBy;
      } else {
        return "PARTY_CODE, PARTY_NAME";
      }
    }

    #endregion Extension methods

    #region Helpers

    static private string BuildKeywordsFilter(string keywords) {
      if (keywords.Length == 0) {
        return string.Empty;
      }
      return SearchExpression.ParseAndLikeKeywords("PARTY_KEYWORDS", keywords);
    }


    static private string BuildOrgUnitTypeFilter() {
      return $"PARTY_TYPE_ID = {OrganizationalUnit.Empty.PartyType.Id}";
    }


    static private string BuildStatusFilter(EntityStatus status) {
      if (status == EntityStatus.All) {
        return "PARTY_STATUS <> 'X'";
      }

      return $"(PARTY_STATUS = '{(char) status}' AND PARTY_ID <> -1)";
    }

    #endregion Helpers

  }  // class OrganizationalStructureQueryBuilder

}  // namespace Empiria.HumanResources.Adapters
