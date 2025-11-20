/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Locations                                     Component : Web Api                              *
*  Assembly : Empiria.Central.WebApi.dll                    Pattern   : Query Web api controller             *
*  Type     : CountriesController                           License   : Please read LICENSE.txt file         *
*                                                                                                            *
*  Summary  : Web API used to retrive countries.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Locations.WebApi {

  /// <summary>Web API used to retrive countries.</summary>
  public class CountriesController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/locations/countries")]
    public CollectionModel GetCountries() {

      FixedList<Country> countries = Country.GetList();

      return new CollectionModel(Request, countries.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class CountriesController

}  // namespace Empiria.Locations.WebApi
