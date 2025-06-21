/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                              Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : SubjectAccountabilityController              License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update accountabilites.                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.Parties;
using Empiria.WebApi;

using Empiria.HumanResources.Adapters;

namespace Empiria.HumanResources.WebApi {

  /// <summary>Web API used to retrive and update accountabilites.</summary>
  public class SubjectAccountabilityController : WebApiController {

    #region Command Web Apis

    [HttpPost]
    [Route("v5/security/management/subjects/{subjectUID:guid}/accountabilities")]
    public CollectionModel CreateAccountability([FromUri] string subjectUID,
                                                [FromBody] PartyRelationFields fields) {

      fields.ResponsibleUID = GetResponsibleParty(subjectUID).UID;

      using (var services = ResponsibleAccountabilityServices.ServiceInteractor()) {
        FixedList<AccountabilityDescriptor> accountabilities = services.CreateAccountability(fields);

        return new CollectionModel(base.Request, accountabilities);
      }
    }


    [HttpDelete]
    [Route("v5/security/management/subjects/{subjectUID:guid}/accountabilities/{accountabilityUID:guid}")]
    public CollectionModel DeleteAccountability([FromUri] string subjectUID,
                                                [FromUri] string accountabilityUID) {

      using (var services = ResponsibleAccountabilityServices.ServiceInteractor()) {
        FixedList<AccountabilityDescriptor> accountabilities = services.DeleteAccountability(accountabilityUID);

        return new CollectionModel(base.Request, accountabilities);
      }
    }


    [HttpGet]
    [Route("v5/security/management/subjects/{subjectUID:guid}/accountabilities/{accountabilityUID:guid}")]
    public SingleObjectModel GetAccountability([FromUri] string subjectUID,
                                               [FromUri] string accountabilityUID) {

      using (var services = ResponsibleAccountabilityServices.ServiceInteractor()) {
        AccountabilityDto accountability = services.GetAccountability(accountabilityUID);

        return new SingleObjectModel(base.Request, accountability);
      }
    }


    [HttpGet]
    [Route("v5/security/management/subjects/{subjectUID:guid}/accountabilities")]
    public CollectionModel GetAccountabilities([FromUri] string subjectUID) {

      Party responsible = GetResponsibleParty(subjectUID);

      using (var services = ResponsibleAccountabilityServices.ServiceInteractor()) {
        FixedList<AccountabilityDescriptor> accountabilities = services.GetAccountabilities(responsible.UID);

        return new CollectionModel(base.Request, accountabilities);
      }
    }


    [HttpGet]
    [Route("v5/security/management/subjects/{subjectUID:guid}/accountabilities/structured-data-for-edition")]
    public SingleObjectModel GetStructureForEditAccountabilities([FromUri] string subjectUID) {

      Party responsible = GetResponsibleParty(subjectUID);

      using (var services = ResponsibleAccountabilityServices.ServiceInteractor()) {
        StructureForEditAccountabilities structure = services.GetStructureForEditAccountabilities(responsible.UID);

        return new SingleObjectModel(base.Request, structure);
      }
    }


    [HttpPost]
    [Route("v5/security/management/subjects/commissioners/search-available")]
    public CollectionModel SearchAvailableCommissioners([FromBody] CommissionerResponsiblesQuery query) {

      query.ResponsibleUID = GetResponsibleParty(query.ResponsibleUID).UID;

      using (var services = ResponsibleAccountabilityServices.ServiceInteractor()) {
        FixedList<NamedEntityDto> responsibles = services.SearchAvailableCommissioners(query);

        return new CollectionModel(base.Request, responsibles);
      }
    }


    [HttpPut, HttpPatch]
    [Route("v5/security/management/subjects/{subjectUID:guid}/accountabilities/{accountabilityUID:guid}")]
    public CollectionModel UpdateAccountability([FromUri] string subjectUID,
                                                [FromUri] string accountabilityUID,
                                                [FromBody] PartyRelationFields fields) {

      fields.UID = accountabilityUID;
      fields.ResponsibleUID = GetResponsibleParty(subjectUID).UID;

      using (var services = ResponsibleAccountabilityServices.ServiceInteractor()) {
        FixedList<AccountabilityDescriptor> accountabilities = services.UpdateAccountability(fields);

        return new CollectionModel(base.Request, accountabilities);
      }
    }

    #endregion Command Web Apis

    #region Helpers

    private Party GetResponsibleParty(string subjectUID) {
      return Party.ParseWithContact(Contacts.Contact.Parse(subjectUID));
    }

    #endregion Helpers

  }  // class SubjectAccountabilityController

}  // namespace Empiria.HumanResources.WebApi
