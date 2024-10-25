/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                     Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : ProductTypeController                        License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive product types.                                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Products.Services;

namespace Empiria.Products.WebApi {

  /// <summary> Web API used to retrive product types.</summary>
  public class ProductTypeController : WebApiController {

    #region Web Apis

    [HttpGet]
    [Route("v8/products/product-types")]
    public SingleObjectModel GetProductTypes() {

      using (var services = ProductTypeServices.ServiceInteractor()) {
        FixedList<NamedEntityDto> productTypes = services.GetProductTypes();

        return new SingleObjectModel(base.Request, productTypes);
      }
    }

    #endregion Web Apis

  }  // class ProductTypeController

}  // namespace Empiria.Products.WebApi
