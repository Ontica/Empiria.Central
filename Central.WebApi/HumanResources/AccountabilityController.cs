/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                              Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : AccountabilityController                     License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update accountabilites.                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.Parties;
using Empiria.WebApi;

using Empiria.HumanResources;

namespace Empiria.Products.WebApi {

  /// <summary>Web API used to retrive and update accountabilites.</summary>
  public class AccountabilityController : WebApiController {

    #region Command Web Apis

    [HttpPost]
    [Route("v8/human-resources/accountabilities")]
    public SingleObjectModel CreateAccountability([FromBody] PartyRelationFields fields) {

      using (var services = AccountabilityServices.ServiceInteractor()) {
        OrganizationalStructureHolder structure = services.CreateAccountability(fields);

        return new SingleObjectModel(base.Request, structure);
      }
    }


    [HttpDelete]
    [Route("v8/human-resources/accountabilities/{accountabilityUID:guid}")]
    public SingleObjectModel DeleteAccountability([FromUri] string accountabilityUID) {

      using (var services = AccountabilityServices.ServiceInteractor()) {
        OrganizationalStructureHolder structure = services.DeleteAccountability(accountabilityUID);

        return new SingleObjectModel(base.Request, structure);
      }
    }


    [HttpGet]
    [Route("v8/human-resources/accountabilities/{accountabilityUID:guid}")]
    public SingleObjectModel GetAccountability([FromUri] string accountabilityUID) {

      using (var services = AccountabilityServices.ServiceInteractor()) {
        AccountabilityDto accountability = services.GetAccountability(accountabilityUID);

        return new SingleObjectModel(base.Request, accountability);
      }
    }


    [HttpPut, HttpPatch]
    [Route("v8/human-resources/accountabilities/{accountabilityUID:guid}")]
    public SingleObjectModel UpdateAccountability([FromUri] string accountabilityUID,
                                                  [FromBody] PartyRelationFields fields) {

      fields.UID = accountabilityUID;

      using (var services = AccountabilityServices.ServiceInteractor()) {
        OrganizationalStructureHolder structure = services.UpdateAccountability(fields);

        return new SingleObjectModel(base.Request, structure);
      }
    }

    #endregion Command Web Apis

  }  // class AccountabilityController

}  // namespace Empiria.Products.WebApi
