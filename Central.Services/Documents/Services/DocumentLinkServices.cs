/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Service provider                        *
*  Type     : DocumentLinkServices                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for link documents to entities.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Documents.Services.Adapters;

namespace Empiria.Documents.Services {

  /// <summary>Services for link documents to entities.</summary>
  static public class DocumentLinkServices {

    #region Services

    static public DocumentLinkDto CreateLink(Document document, BaseObject linkedEntity) {
      Assertion.Require(document, nameof(document));
      Assertion.Require(linkedEntity, nameof(linkedEntity));


      var link = new DocumentLink(document, linkedEntity);

      link.Save();

      return DocumentLinkMapper.Map(link);
    }


    static public DocumentLinkDto CreateLink(DocumentLinkType linkType, Document document,
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


    static public DocumentLinkDto GetLink(string documentLinkUID) {
      Assertion.Require(documentLinkUID, nameof(documentLinkUID));

      var link = DocumentLink.Parse(documentLinkUID);

      return DocumentLinkMapper.Map(link);
    }


    static public FixedList<DocumentLinkDto> GetDocumentLinks(Document document) {
      Assertion.Require(document, nameof(document));

      FixedList<DocumentLink> links = DocumentLink.GetListFor(document);

      return DocumentLinkMapper.Map(links);
    }


    static public FixedList<Document> GetDocumentsForEntity(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      return DocumentLink.GetDocumentsFor(entity);
    }


    static public DocumentLinkDto RemoveLink(string documentLinkUID) {
      Assertion.Require(documentLinkUID, nameof(documentLinkUID));

      var link = DocumentLink.Parse(documentLinkUID);

      link.Delete();

      link.Save();

      return DocumentLinkMapper.Map(link);
    }


    static public DocumentLinkDto UpdateLink(DocumentLinkFields fields) {
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
