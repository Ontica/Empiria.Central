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
    [Route("v8/products/{productUID:guid}/activate")]
    public SingleObjectModel ActivateProduct([FromUri] string productUID) {

      using (var services = ProductServices.ServiceInteractor()) {
        ProductDto product = services.ActivateProduct(productUID);

        return new SingleObjectModel(base.Request, product);
      }
    }


    [HttpPost]
    [Route("v8/products")]
    public SingleObjectModel CreateProduct([FromBody] ProductFields fields) {

      base.RequireBody(fields);

      using (var services = ProductServices.ServiceInteractor()) {
        ProductDto product = services.CreateProduct(fields);

        return new SingleObjectModel(base.Request, product);
      }
    }


    [HttpDelete]
    [Route("v8/products/{productUID:guid}")]
    public NoDataModel DeleteProduct([FromUri] string productUID) {

      using (var services = ProductServices.ServiceInteractor()) {
        _ = services.DeleteProduct(productUID);

        return new NoDataModel(base.Request);
      }
    }


    [HttpGet]
    [Route("v8/products/{productUID:guid}")]
    public SingleObjectModel GetProduct([FromUri] string productUID) {

      using (var services = ProductServices.ServiceInteractor()) {
        ProductDto product = services.GetProduct(productUID);

        return new SingleObjectModel(base.Request, product);
      }
    }


    [HttpGet]
    [Route("v8/products/search")]
    public CollectionModel SearchProducts([FromUri] string keywords) {

      using (var services = ProductServices.ServiceInteractor()) {
        FixedList<ProductDescriptorDto> products = services.SearchProducts(keywords);

        return new CollectionModel(base.Request, products);
      }
    }


    [HttpPost]
    [Route("v8/products/search")]
    public CollectionModel SearchProducts([FromBody] ProductsQuery query) {

      base.RequireBody(query);

      using (var services = ProductServices.ServiceInteractor()) {
        FixedList<ProductDescriptorDto> products = services.SearchProducts(query);

        return new CollectionModel(base.Request, products);
      }
    }


    [HttpPost]
    [Route("v8/products/search/short-list")]
    public CollectionModel SearchProductsAsShortList([FromBody] ProductsQuery query) {

      using (var services = ProductServices.ServiceInteractor()) {
        FixedList<ProductDescriptorDto> products = services.SearchProducts(query);

        return new CollectionModel(base.Request, products.MapToNamedEntityList());
      }
    }


    [HttpPost]
    [Route("v8/products/{productUID:guid}/suspend")]
    public SingleObjectModel SuspendProduct([FromUri] string productUID) {

      using (var services = ProductServices.ServiceInteractor()) {
        ProductDto product = services.SuspendProduct(productUID);

        return new SingleObjectModel(base.Request, product);
      }
    }


    [HttpPut, HttpPatch]
    [Route("v8/products/{productUID:guid}")]
    public SingleObjectModel UpdateProduct([FromUri] string productUID,
                                           [FromBody] ProductFields fields) {

      base.RequireBody(fields);

      Assertion.Require(productUID == fields.UID, "fields.UID mismatch");

      using (var services = ProductServices.ServiceInteractor()) {
        ProductDto product = services.UpdateProduct(fields);

        return new SingleObjectModel(base.Request, product);
      }
    }

    #endregion Web Apis

  }  // class ProductController

}  // namespace Empiria.Products.WebApi
