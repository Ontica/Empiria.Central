/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : DocumentLinkServices                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for DocumentLink instances.                                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Documents.Services.Adapters;
using System;

namespace Empiria.Documents.Services {

  /// <summary>Services for DocumentLink instances.</summary>
  public class DocumentLinkServices : Service {

    #region Constructors and parsers

    protected DocumentLinkServices() {
      // no-op
    }

    static public DocumentLinkServices ServiceInteractor() {
      return Service.CreateInstance<DocumentLinkServices>();
    }

    #endregion Constructors and parsers

    #region Services

    internal DocumentLinkDto CreateLink(Document document, BaseObject linkedEntity) {
      Assertion.Require(document, nameof(document));
      Assertion.Require(linkedEntity, nameof(linkedEntity));


      var link = new DocumentLink(document, linkedEntity);

      link.Save();

      return DocumentLinkMapper.Map(link);
    }


    public DocumentLinkDto CreateLink(DocumentLinkType linkType, Document document,
                                      BaseObject linkedEntity,
                                      DocumentLinkFields fields) {
      Assertion.Require(linkType, nameof(linkType));
      Assertion.Require(document, nameof(document));
      Assertion.Require(linkedEntity, nameof(linkedEntity));
      Assertion.Require(fields, nameof(fields));

      var link = new DocumentLink(linkType, document, linkedEntity);

      link.Update(fields);

      link.Save();

      return DocumentLinkMapper.Map(link);
    }


    public DocumentLinkDto DeleteLink(string documentLinkUID) {
      Assertion.Require(documentLinkUID, nameof(documentLinkUID));

      var link = DocumentLink.Parse(documentLinkUID);

      link.Delete();

      link.Save();

      return DocumentLinkMapper.Map(link);
    }


    public DocumentLinkDto GetLink(string documentLinkUID) {
      Assertion.Require(documentLinkUID, nameof(documentLinkUID));

      var link = DocumentLink.Parse(documentLinkUID);

      return DocumentLinkMapper.Map(link);
    }


    public FixedList<DocumentLinkDto> GetDocumentLinks(Document document) {
      Assertion.Require(document, nameof(document));

      FixedList<DocumentLink> links = DocumentLink.GetListFor(document);

      return DocumentLinkMapper.Map(links);
    }


    public FixedList<Document> GetDocumentsForEntity(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      return DocumentLink.GetDocumentsFor(entity);
    }


    public DocumentLinkDto UpdateLink(DocumentLinkFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var link = DocumentLink.Parse(fields.UID);

      link.Update(fields);

      link.Save();

      return DocumentLinkMapper.Map(link);
    }

    #endregion Services

  }  // class DocumentLinkServices

}  // namespace Empiria.Documents.Services
