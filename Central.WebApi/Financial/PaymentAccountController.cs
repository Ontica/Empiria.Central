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

using Empiria.Financial.Adapters;

namespace Empiria.Financial.WebApi {

  /// <summary>Query web API used to retrive and update payment accounts.</summary>
  public class PaymentAccountController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/financial/financial-institutions")]
    public CollectionModel GetFinancialInstitutions() {

      FixedList<FinancialInstitution> institutions = FinancialInstitution.GetList();

      return new CollectionModel(Request, institutions.MapToNamedEntityList());
    }


    [HttpGet]
    [Route("v8/financial/payment-account-types")]
    public CollectionModel GetPaymentAccountTypes() {

      FixedList<PaymentAccountType> accountTypes = PaymentAccountType.GetList();

      return new CollectionModel(Request, accountTypes.MapToNamedEntityList());
    }


    [HttpGet]
    [Route("v8/financial/payment-methods")]
    public CollectionModel GetPaymentMethods() {

      FixedList<PaymentMethod> paymentMethods = PaymentMethod.GetList();

      FixedList<PaymentMethodDto> dtos = PaymentMethodDto.Map(paymentMethods);

      return new CollectionModel(Request, dtos);
    }

    #endregion Query web apis

  }  // class PaymentAccountController

}  // namespace Empiria.Financial.WebApi
