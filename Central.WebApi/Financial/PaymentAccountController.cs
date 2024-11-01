/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                    Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Query web api controller              *
*  Type     : PaymentAccountController                     License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Query web API used to retrive and update payment accounts.                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

using Empiria.Parties;

namespace Empiria.Financial.WebApi {

  /// <summary>Query web API used to retrive and update payment accounts.</summary>
  public class PaymentAccountController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/financial/parties/{partyUID:guid}/payment-accounts")]
    public CollectionModel GetPartyPaymentAccounts([FromUri] string partyUID) {

      var party = Party.Parse(partyUID);

      FixedList<PaymentAccount> paymentAccounts = PaymentAccount.GetListFor(party);

      return new CollectionModel(Request, paymentAccounts.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class PaymentAccountController

}  // namespace Empiria.Financial.WebApi
