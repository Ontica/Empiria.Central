﻿/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                    Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : DocumentController                           License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update documents.                                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

namespace Empiria.Documents.WebApi {

  /// <summary>Web API used to retrive and update documents.</summary>
  public class DocumentController : WebApiController {

    #region Web Apis

    [HttpGet]
    [Route("v8/documents/{documentUID:guid}")]
    public SingleObjectModel GetDocument([FromUri] string documentUID) {

      DocumentDto document = DocumentServices.GetDocument(documentUID);

      return new SingleObjectModel(base.Request, document);
    }



    [HttpGet]
    [Route("v8/documents/entities/{entityType}/{entityUID:guid}")]
    public CollectionModel GetEntityDocument([FromUri] string entityType,
                                             [FromUri] string entityUID) {

      BaseObject entity = BaseObject.Parse(entityType, entityUID);

      FixedList<DocumentDto> documents = DocumentServices.GetAllEntityDocuments(entity);

      return new CollectionModel(base.Request, documents);
    }


    [HttpPost]
    [Route("v8/documents/search")]
    public CollectionModel SearchDocuments([FromBody] DocumentsQuery query) {

      base.RequireBody(query);

      FixedList<DocumentDescriptorDto> documents = DocumentServices.SearchDocuments(query);

      return new CollectionModel(base.Request, documents);
    }


    //[HttpPut, HttpPatch]
    //[Route("v8/documents/{documentUID:guid}")]
    //public SingleObjectModel UpdateDocument([FromUri] string documentUID,
    //                                        [FromBody] DocumentFields fields) {

    //  base.RequireBody(fields);

    //  Assertion.Require(documentUID == fields.UID, "fields.UID mismatch");

    //  DocumentDto document = DocumentServices.UpdateDocument(fields);

    //  return new SingleObjectModel(base.Request, document);
    //}

    #endregion Web Apis

  }  // class DocumentController

}  // namespace Empiria.Documents.WebApi
