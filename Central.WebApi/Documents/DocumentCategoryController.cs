/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                    Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : DocumentCategoryController                   License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update document categories.                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

using Empiria.Documents.Services;
using Empiria.Documents.Services.Adapters;

namespace Empiria.Documents.WebApi {

  /// <summary>Web API used to retrive and update document categories.</summary>
  public class DocumentCategoryController : WebApiController {

    #region Web Apis

    [HttpGet]
    [Route("v8/documents/categories")]
    public CollectionModel GetDocumentCategories() {

      using (var services = DocumentCategoryServices.ServiceInteractor()) {

        FixedList<DocumentCategoryDto> categories = services.GetDocumentCategories();

        return new CollectionModel(base.Request, categories);
      }
    }

    #endregion Web Apis

  }  // class DocumentCategoryController

}  // namespace Empiria.Documents.WebApi
