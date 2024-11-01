/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : DocumentServices                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for Document instances.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Services;
using Empiria.Storage;

using Empiria.Documents.Services.Adapters;

namespace Empiria.Documents.Services {

  /// <summary>Services for Document instances.</summary>
  public class DocumentServices : Service {

    #region Constructors and parsers

    protected DocumentServices() {
      // no-op
    }

    static public DocumentServices ServiceInteractor() {
      return Service.CreateInstance<DocumentServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public DocumentDto CreateDocument(InputFile inputFile,
                                      BaseObject baseEntity,
                                      DocumentFields fields) {

      Assertion.Require(inputFile, nameof(inputFile));
      Assertion.Require(baseEntity, nameof(baseEntity));
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Assertion.Require(fields.DocumentCategoryUID, nameof(fields.DocumentCategoryUID));
      Assertion.Require(fields.Name, nameof(fields.Name));

      var category = DocumentCategory.Parse(fields.DocumentCategoryUID);

      FileData fileData = category.FileLocation.Store(inputFile);

      var document = new Document(category, baseEntity, fileData, fields.Name);

      document.Update(fields);

      document.Save();

      return DocumentMapper.Map(document);
    }


    public DocumentDto DeleteDocument(string documentUID) {
      Assertion.Require(documentUID, nameof(documentUID));

      var document = Document.Parse(documentUID);

      document.Delete();

      document.Save();

      return DocumentMapper.Map(document);
    }


    public DocumentDto GetDocument(string documentUID) {
      Assertion.Require(documentUID, nameof(documentUID));

      var document = Document.Parse(documentUID);

      return DocumentMapper.Map(document);
    }


    public FixedList<DocumentDto> GetEntityDocuments(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      FixedList<Document> documents = Document.GetListFor(entity);

      return DocumentMapper.Map(documents);
    }


    public FixedList<DocumentDescriptorDto> SearchDocuments(DocumentsQuery query) {
      Assertion.Require(query, nameof(query));

      return new FixedList<DocumentDescriptorDto>();
    }


    public DocumentDto UpdateDocument(DocumentFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var document = Document.Parse(fields.UID);

      document.Update(fields);

      document.Save();

      return DocumentMapper.Map(document);
    }

    #endregion Services

  }  // class DocumentServices

}  // namespace Empiria.Documents.Services
