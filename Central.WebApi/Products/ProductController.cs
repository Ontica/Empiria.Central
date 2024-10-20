/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                     Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : ProductController                            License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update products.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Products.Services;
using Empiria.Products.Services.Adapters;

namespace Empiria.Products.WebApi {

  /// <summary>Web API used to retrive and update products.</summary>
  public class ProductController : WebApiController {

    #region Web Apis

    [HttpPost]
    [Route("v2/products")]
    public SingleObjectModel CreateProduct(ProductFields fields) {

      base.RequireBody(fields);

      using (var services = ProductServices.ServiceInteractor()) {
        ProductDto product = services.CreateProduct(fields);

        return new SingleObjectModel(base.Request, product);
      }
    }


    [HttpDelete]
    [Route("v2/products/{productUID:guid}")]
    public NoDataModel DeleteProduct([FromUri] string productUID) {

      using (var services = ProductServices.ServiceInteractor()) {
        _ = services.DeleteProduct(productUID);

        return new NoDataModel(base.Request);
      }
    }


    [HttpGet]
    [Route("v2/products/{productUID:guid}")]
    public SingleObjectModel GetProduct([FromUri] string productUID) {

      using (var services = ProductServices.ServiceInteractor()) {
        ProductDto product = services.GetProduct(productUID);

        return new SingleObjectModel(base.Request, product);
      }
    }


    [HttpGet]
    [Route("v2/products")]
    public CollectionModel SearchProducts() {

      using (var services = ProductServices.ServiceInteractor()) {
        FixedList<ProductDto> products = services.SearchProducts();

        return new CollectionModel(base.Request, products);
      }
    }


    [HttpPut, HttpPatch]
    [Route("v2/products/{productUID:guid}")]
    public SingleObjectModel UpdateProduct(ProductFields fields) {

      base.RequireBody(fields);

      using (var services = ProductServices.ServiceInteractor()) {
        ProductDto product = services.UpdateProduct(fields);

        return new SingleObjectModel(base.Request, product);
      }
    }

    #endregion Web Apis

  }  // class ProductController

}  // namespace Empiria.Products.WebApi
