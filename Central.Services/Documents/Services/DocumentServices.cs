/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services provider                       *
*  Type     : DocumentServices                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for Document instances.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Storage;

using Empiria.Documents.Services.Adapters;
using Empiria.Products;
using System;

namespace Empiria.Documents.Services {

  /// <summary>Services for Document instances.</summary>
  static public class DocumentServices {

    #region Services

    static public DocumentDto GetDocument(string documentUID) {
      Assertion.Require(documentUID, nameof(documentUID));

      var document = Document.Parse(documentUID);

      return DocumentMapper.Map(document);
    }


    static public FixedList<DocumentDto> GetEntityDocuments(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      FixedList<Document> documents = Document.GetListFor(entity);

      return DocumentMapper.Map(documents);
    }


    static public DocumentDto RemoveDocument(BaseObject entity, Document document) {
      Assertion.Require(entity, nameof(entity));
      Assertion.Require(document, nameof(document));

      Assertion.Require(document.BaseEntityId == entity.Id, "Document entity mismatch.");

      document.Delete();

      document.Save();

      return DocumentMapper.Map(document);
    }


    static public FixedList<DocumentDescriptorDto> SearchDocuments(DocumentsQuery query) {
      Assertion.Require(query, nameof(query));

      return new FixedList<DocumentDescriptorDto>();
    }


    static public DocumentDto StoreDocument(InputFile inputFile,
                                            BaseObject baseEntity,
                                            DocumentFields fields) {

      Assertion.Require(inputFile, nameof(inputFile));
      Assertion.Require(baseEntity, nameof(baseEntity));
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Assertion.Require(fields.DocumentProductUID, nameof(fields.DocumentProductUID));
      Assertion.Require(fields.Name, nameof(fields.Name));

      var product = Product.Parse(fields.DocumentProductUID);
      var category = (DocumentCategory) product.ProductCategory;

      FileData fileData = category.FileLocation.Store(inputFile);

      var document = new Document(product, baseEntity, fileData, fields.Name);

      document.Update(fields);

      document.Save();

      return DocumentMapper.Map(document);
    }


    static public DocumentDto UpdateDocument(BaseObject entity, Document document, DocumentFields fields) {
      Assertion.Require(entity, nameof(entity));
      Assertion.Require(document, nameof(document));
      Assertion.Require(fields, nameof(fields));

      Assertion.Require(document.BaseEntityId == entity.Id, "Document entity mismatch.");

      fields.EnsureValid();

      document.Update(fields);

      document.Save();

      return DocumentMapper.Map(document);
    }

    #endregion Services

  }  // class DocumentServices

}  // namespace Empiria.Documents.Services
