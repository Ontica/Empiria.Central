/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Services Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Services provider                       *
*  Type     : OrganizationalStructureServices            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides services to update and retrieve organizational structures.                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Parties;

using Empiria.HumanResources.Adapters;

namespace Empiria.HumanResources {

  /// <summary>Provides services to update and retrieve organizational structures.</summary>
  public class OrganizationalStructureServices : Service {

    #region Constructors and parsers

    protected OrganizationalStructureServices() {
      // no-op
    }

    static public OrganizationalStructureServices ServiceInteractor() {
      return Service.CreateInstance<OrganizationalStructureServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public OrganizationalStructureHolder GetOrganizationalStructure(string orgUnitUID) {
      Assertion.Require(orgUnitUID, nameof(orgUnitUID));

      var orgUnit = OrganizationalUnit.Parse(orgUnitUID);

      return OrganizationalUnitMapper.Map(orgUnit);
    }


    public FixedList<OrganizationalUnitDescriptor> SearchOrganizationalStructure(OrganizationalStructureQuery query) {
      Assertion.Require(query, nameof(query));

      string filter = query.MapToFilterString();

      string sort = query.MapToSortString();

      FixedList<OrganizationalUnit> orgUnits = HumanResourcesDataService.SearchOrganizationalUnits(filter, sort);

      return OrganizationalUnitMapper.Map(orgUnits);
    }

    #endregion Services

  }  // class OrganizationalStructureServices

}  // namespace Empiria.HumanResources
