/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Parties                                      Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web api controller                    *
*  Type     : ProductManagerController                     License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Query web API used to retrive and update products managers.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

using Empiria.Parties;

namespace Empiria.Products.WebApi {

  /// <summary>Query web API used to retrive and update products managers.</summary>
  public class ProductManagerController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/products/primary-party/product-managers")]
    public CollectionModel GetProductManagers([FromUri] string keywords = "") {

      FixedList<Party> productManagers = Party.GetPartiesInRole("product-manager");

      return new CollectionModel(Request, productManagers.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class ProductManagerController

}  // namespace Empiria.Products.WebApi
