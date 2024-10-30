/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : DocumentServices                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for Document instances.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Documents.Services.Adapters;
using System;

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

    public DocumentDto CreateDocument(BaseObject baseEntity, DocumentFields fields) {
      Assertion.Require(baseEntity, nameof(baseEntity));
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Assertion.Require(fields.DocumentCategoryUID, nameof(fields.DocumentCategoryUID));
      Assertion.Require(fields.Name, nameof(fields.Name));

      var documentCategory = DocumentCategory.Parse(fields.DocumentCategoryUID);

      var document = new Document(documentCategory, baseEntity, fields.Name);

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


    public FixedList<DocumentDto> GetDocumentsForEntity(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      FixedList<Document> documents = Document.GetListFor(entity);

      return DocumentMapper.Map(documents);
    }


    public DocumentDto UpdateDocument(DocumentFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var document = Document.Parse(fields.UID);

      document.Update(fields);

      document.Save();

      return DocumentMapper.Map(document);
    }

    internal object GetDocumentsForEntity(object dOCUMENT_ENTITY) {
      throw new NotImplementedException();
    }

    #endregion Services

  }  // class DocumentServices

}  // namespace Empiria.Documents.Services
