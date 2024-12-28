/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Time                                         Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : TimeController                               License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive time-related instances.                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Time.WebApi {

  /// <summary>Web API used to retrive and update projects.</summary>
  public class TimeController : WebApiController {

    #region Web Apis

    [HttpGet]
    [Route("v8/time/periodicity-types")]
    public CollectionModel GetPeriodicityTypes() {

      var list = BaseObject.GetFullList<Periodicity>()
                           .MapToNamedEntityList();

      return new CollectionModel(base.Request, list);
    }

    #endregion Web Apis

  }  // class TimeController

}  // namespace Empiria.Time.WebApi
