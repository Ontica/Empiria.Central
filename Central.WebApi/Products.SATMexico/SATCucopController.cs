/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Budget Products                              Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web api controller                    *
*  Type     : SATCucopController                           License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API para leer y actualizar el catálogo CUCoP del SAT México.                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Products.SATMexico.WebApi {

  /// <summary>Web API para leer y actualizar el catálogo CUCoP del SAT México.</summary>
  public class SATCucopController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v2/products/sat-mexico/cucop-product")]
    public CollectionModel SearchSATCucopProducts([FromUri] string keywords) {
      FixedList<SATCucop> list = SATCucop.GetList();

      return new CollectionModel(Request, list.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class SATCucopController

}  // namespace Empiria.Products.SATMexico.WebApi
