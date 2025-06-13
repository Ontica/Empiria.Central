/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                              Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : OrganizationalStructureController            License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update organizational structures.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

using Empiria.HumanResources;
using Empiria.HumanResources.Adapters;

namespace Empiria.Products.WebApi {

  /// <summary>Web API used to retrive and update organizational structures.</summary>
  public class OrganizationalStructureController : WebApiController {

    #region Query Web Apis

    [HttpGet]
    [Route("v8/human-resources/organizational-structure/{orgUnitUID:guid}")]
    public SingleObjectModel GetOrganizationalStructure([FromUri] string orgUnitUID) {

      using (var services = OrganizationalStructureServices.ServiceInteractor()) {
        OrganizationalStructureHolder structure = services.GetOrganizationalStructure(orgUnitUID);

        return new SingleObjectModel(base.Request, structure);
      }
    }


    [HttpPost]
    [Route("v8/human-resources/organizational-structure/search")]
    public SingleObjectModel SearchOrganizationalStructure([FromBody] OrganizationalStructureQuery query) {

      using (var services = OrganizationalStructureServices.ServiceInteractor()) {
        FixedList<OrganizationalUnitDescriptor> structure = services.SearchOrganizationalStructure(query);

        return new SingleObjectModel(base.Request, structure);
      }
    }

    #endregion Query Web Apis

  }  // class OrganizationalStructureController

}  // namespace Empiria.Products.WebApi
