/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                    Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Query web api controller              *
*  Type     : FinancialCataloguesController                License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Query web API used to retrive financial types catalogues.                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Financial.WebApi {

  /// <summary>Query web API used to retrive currencies.</summary>
  public class FinancialCataloguesController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/financial/currencies")]
    public CollectionModel GetCurrencies() {

      FixedList<Currency> currencies = Currency.GetList();

      return new CollectionModel(Request, currencies.MapToNamedEntityList());
    }


    [HttpGet]
    [Route("v8/financial/interest-rate-types")]
    public CollectionModel GetInterestRateTypes() {

      FixedList<InterestRateType> interestRateTypes = InterestRateType.GetList();

      return new CollectionModel(Request, interestRateTypes.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class FinancialCataloguesController

}  // namespace Empiria.Financial.WebApi
