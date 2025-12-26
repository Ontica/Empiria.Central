/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                     Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web api controller                    *
*  Type     : ProductUnitController                        License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Query web API used to retrive and update product units.                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Products.WebApi {

  /// <summary>Query web API used to retrive and update product units.</summary>
  public class ProductUnitController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/product-management/product-units")]
    public CollectionModel SearchProductUnits([FromUri] string keywords = "") {

      FixedList<ProductUnit> productUnits = ProductUnit.GetList();

      return new CollectionModel(Request, productUnits.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class ProductUnitController

}  // namespace Empiria.Products.WebApi
