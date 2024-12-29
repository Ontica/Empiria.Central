/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                    Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web api controller                    *
*  Type     : PaymentAccountController                     License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update payment accounts.                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

using Empiria.Financial.Services;
using Empiria.Financial.Adapters;

namespace Empiria.Financial.WebApi {

  /// <summary>Query web API used to retrive and update payment accounts.</summary>
  public class PaymentAccountController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/financial/parties/{partyUID:guid}/payment-accounts")]
    public CollectionModel GetPartyPaymentAccounts([FromUri] string partyUID) {

      FixedList<PaymentAccountDto> accounts = PaymentAccountServices.GetPaymentAccounts(partyUID);

      return new CollectionModel(Request, accounts);
    }

    #endregion Query web apis

  }  // class PaymentAccountController

}  // namespace Empiria.Financial.WebApi
