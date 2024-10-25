/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                          Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web api controller                    *
*  Type     : SATProductoController                        License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API para leer y actualizar el catálogo de productos y servicios para la facturación        *
*             electrónica de acuerdo al SAT México.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Products.SATMexico.WebApi {

  /// <summary>Web API para leer y actualizar el catálogo de productos y servicios para la facturación
  ///electrónica de acuerdo al SAT México.</summary>
  public class SATProductoController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/products/sat-mexico/productos")]
    public CollectionModel SearchSATProductos([FromUri] string keywords = "") {
      FixedList<SATProducto> list = SATProducto.GetList();

      return new CollectionModel(Request, list.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class SATProductoController

}  // namespace Empiria.Products.SATMexico.WebApi
