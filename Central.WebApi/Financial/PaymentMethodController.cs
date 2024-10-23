/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                    Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Query web api controller              *
*  Type     : CurrencyController                           License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Query web API used to retrive currencies.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Financial.WebApi {

  /// <summary>Query web API used to retrive currencies.</summary>
  public class PaymentMethodController : WebApiController {

    #region Query web apis
 
    [HttpGet]
    [Route("v2/payments-management/payment-methods")]

    [Route("v2/financial/catalogues/payment-methods")]
    [Route("v2/financial/payment-methods")]
    public CollectionModel GetPaymentMethods() {
  
      FixedList<PaymentMethod> paymentMethods = PaymentMethod.GetList();

      return new CollectionModel(Request, paymentMethods.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class CurrencyController

}  // namespace Empiria.Financial.WebApi
