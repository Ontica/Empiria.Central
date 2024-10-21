/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                     Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : ProductCategoryController                    License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update product categories.                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Products.Services;
using Empiria.Products.Services.Adapters;

namespace Empiria.Products.WebApi {

  /// <summary>Web API used to retrive and update product categories.</summary>
  public class ProductCategoryController : WebApiController {

    #region Web Apis

    [HttpPost]
    [Route("v2/products/categories")]
    public SingleObjectModel CreateProductCategory(ProductCategoryFields fields) {

      base.RequireBody(fields);

      using (var services = ProductCategoryServices.ServiceInteractor()) {
        ProductCategoryDto category = services.CreateProductCategory(fields);

        return new SingleObjectModel(base.Request, category);
      }
    }


    [HttpDelete]
    [Route("v2/products/categories/{productCategoryUID:guid}")]
    public NoDataModel DeleteProductCategory([FromUri] string productCategoryUID) {

      using (var services = ProductCategoryServices.ServiceInteractor()) {
        _ = services.DeleteProductCategory(productCategoryUID);

        return new NoDataModel(base.Request);
      }
    }


    [HttpGet]
    [Route("v2/products/categories/{productCategoryUID:guid}")]
    public SingleObjectModel GetProductCategory([FromUri] string productCategoryUID) {

      using (var services = ProductCategoryServices.ServiceInteractor()) {
        ProductCategoryDto category = services.GetProductCategory(productCategoryUID);

        return new SingleObjectModel(base.Request, category);
      }
    }


    [HttpGet]
    [Route("v2/products/categories")]
    public CollectionModel SearchProductCategories([FromUri] string keywords) {

      using (var services = ProductCategoryServices.ServiceInteractor()) {
        FixedList<ProductCategoryDto> categories = services.SearchProductCategories(keywords);

        return new CollectionModel(base.Request, categories);
      }
    }


    [HttpPut, HttpPatch]
    [Route("v2/products/categories{productUID:guid}")]
    public SingleObjectModel UpdateProductCategory(ProductCategoryFields fields) {

      base.RequireBody(fields);

      using (var services = ProductCategoryServices.ServiceInteractor()) {
        ProductCategoryDto category = services.UpdateProductCategory(fields);

        return new SingleObjectModel(base.Request, category);
      }
    }

    #endregion Web Apis

  }  // class ProductCategoryController

}  // namespace Empiria.Products.WebApi
