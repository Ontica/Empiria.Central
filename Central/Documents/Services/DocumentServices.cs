/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Services provider                       *
*  Type     : DocumentServices                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for Document instances.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Collections.Generic;
using System.Linq;

using Empiria.Storage;

namespace Empiria.Documents {

  /// <summary>Services for Document instances.</summary>
  static public class DocumentServices {

    #region Services

    static public DocumentDto GetDocument(string documentUID) {
      Assertion.Require(documentUID, nameof(documentUID));

      var document = Document.Parse(documentUID);

      return DocumentMapper.Map(document);
    }


    static public FixedList<DocumentDto> GetAllEntityDocuments(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      FixedList<Document> baseDocuments = Document.GetListFor(entity);
      FixedList<Document> relatedDocuments = DocumentLink.GetDocumentsFor(entity);

      var allDocuments = new List<Document>(baseDocuments);

      allDocuments.AddRange(relatedDocuments);

      return DocumentMapper.Map(allDocuments.Distinct().ToFixedList());
    }


    static public FixedList<DocumentDto> GetEntityDocuments(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      FixedList<Document> documents = Document.GetListFor(entity);

      return DocumentMapper.Map(documents.ToFixedList());
    }


    static public void RemoveAllDocuments(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      FixedList<Document> documents = Document.GetListFor(entity);

      foreach (var document in documents) {
        foreach (var link in DocumentLink.GetListFor(document)) {
          link.Delete();
          link.Save();
        }
        document.Delete();
        document.Save();
      }
    }


    static public DocumentDto RemoveDocument(BaseObject entity, DocumentDto documentDto) {
      Assertion.Require(entity, nameof(entity));
      Assertion.Require(documentDto, nameof(documentDto));

      Document document = Document.Parse(documentDto.UID);

      Assertion.Require(document.BaseEntityId == entity.Id, "Document entity mismatch.");

      foreach (var link in DocumentLink.GetListFor(document)) {
        link.Delete();
        link.Save();
      }

      document.Delete();

      document.Save();

      return DocumentMapper.Map(document);
    }


    static public FixedList<DocumentDescriptorDto> SearchDocuments(DocumentsQuery query) {
      Assertion.Require(query, nameof(query));

      return new FixedList<DocumentDescriptorDto>();
    }


    static public DocumentDto StoreDocument(InputFile inputFile,
                                            BaseObject entity,
                                            DocumentFields fields) {

      Assertion.Require(inputFile, nameof(inputFile));
      Assertion.Require(entity, nameof(entity));
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Assertion.Require(fields.DocumentProductUID, nameof(fields.DocumentProductUID));
      Assertion.Require(fields.Name, nameof(fields.Name));

      var product = DocumentProduct.Parse(fields.DocumentProductUID);

      FileData fileData = product.ProductCategory.FileLocation.Store(inputFile);

      var document = new Document(product, entity, fileData, fields.Name);

      document.Update(fields);

      document.Save();

      return DocumentMapper.Map(document);
    }


    static public DocumentDto UpdateDocument(BaseObject entity, DocumentDto documentDto, DocumentFields fields) {
      Assertion.Require(entity, nameof(entity));
      Assertion.Require(documentDto, nameof(documentDto));
      Assertion.Require(fields, nameof(fields));

      Document document = Document.Parse(documentDto.UID);

      Assertion.Require(document.BaseEntityId == entity.Id, "Document entity mismatch.");

      fields.EnsureValid();

      document.Update(fields);

      document.Save();

      return DocumentMapper.Map(document);
    }


    #endregion Services

  }  // class DocumentServices

}  // namespace Empiria.Documents
