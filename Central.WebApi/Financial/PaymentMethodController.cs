/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                    Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Query web api controller              *
*  Type     : PaymentMethodController                      License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Query web API used to retrive payment methods.                                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

using Empiria.Financial.Services;
using Empiria.Financial.Adapters;

namespace Empiria.Financial.WebApi {

  /// <summary>Query web API used to retrive payment methods.</summary>
  public class PaymentMethodController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/financial/payment-methods")]
    public CollectionModel GetPaymentMethods() {

      using (var services = PaymentMethodServices.ServiceInteractor()) {
        FixedList<PaymentMethodDto> paymentMethods = services.GetPaymentMethods();

        return new CollectionModel(Request, paymentMethods);
      }
    }

    #endregion Query web apis

  }  // class PaymentMethodController

}  // namespace Empiria.Financial.WebApi
