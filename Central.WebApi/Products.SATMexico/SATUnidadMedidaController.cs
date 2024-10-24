/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                          Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web api controller                    *
*  Type     : SATUnidadMedidaController                    License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API para leer y actualizar el catálogo de unidades de medida para la facturación           *
*             electrónica de acuerdo al SAT México.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Products.SATMexico.WebApi {

  /// <summary>WWeb API para leer y actualizar el catálogo de unidades de medida para la facturación
  /// electrónica de acuerdo al SAT México.</summary>
  public class SATUnidadMedidaController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v2/products/sat-mexico/unidades-medida")]
    public CollectionModel SearchSATUnidadesMedida([FromUri] string keywords = "") {
      FixedList<SATUnidadMedida> list = SATUnidadMedida.GetList();

      return new CollectionModel(Request, list.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class SATUnidadMedidaController

}  // namespace Empiria.Products.SATMexico.WebApi
