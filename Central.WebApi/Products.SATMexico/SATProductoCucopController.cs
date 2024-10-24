/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                          Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web api controller                    *
*  Type     : SATProductoCucopController                   License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API para leer y actualizar los productos del catálogo CUCoP del SAT México.                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Products.SATMexico.WebApi {

  /// <summary>Web API para leer y actualizar los productos del catálogo CUCoP del SAT México.</summary>
  public class SATProductoCucopController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v2/products/sat-mexico/productos-cucop")]
    public CollectionModel SearchSATCucopProducts([FromUri] string keywords = "") {
      FixedList<SATProductoCucop> list = SATProductoCucop.GetList();

      return new CollectionModel(Request, list.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class SATProductoCucopController

}  // namespace Empiria.Products.SATMexico.WebApi
