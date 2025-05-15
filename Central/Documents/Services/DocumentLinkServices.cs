/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Service provider                        *
*  Type     : DocumentLinkServices                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for link documents to entities.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Documents {

  /// <summary>Services for link documents to entities.</summary>
  static public class DocumentLinkServices {

    #region Services

    static public DocumentLinkDto CreateLink(DocumentDto documentDto, BaseObject linkedEntity) {
      Assertion.Require(documentDto, nameof(documentDto));
      Assertion.Require(linkedEntity, nameof(linkedEntity));

      var document = Document.Parse(documentDto.UID);

      var link = new DocumentLink(document, linkedEntity);

      link.Save();

      return DocumentLinkMapper.Map(link);
    }


    static public DocumentLinkDto CreateLink(DocumentLinkType linkType, DocumentDto documentDto,
                                             BaseObject linkedEntity,
                                             DocumentLinkFields fields) {
      Assertion.Require(linkType, nameof(linkType));
      Assertion.Require(documentDto, nameof(documentDto));
      Assertion.Require(linkedEntity, nameof(linkedEntity));
      Assertion.Require(fields, nameof(fields));

      var document = Document.Parse(documentDto.UID);

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


    static public FixedList<DocumentLinkDto> GetDocumentLinks(DocumentDto documentDto) {
      Assertion.Require(documentDto, nameof(documentDto));

      var document = Document.Parse(documentDto.UID);

      FixedList<DocumentLink> links = DocumentLink.GetListFor(document);

      return DocumentLinkMapper.Map(links);
    }


    static public FixedList<DocumentDto> GetDocumentsForEntity(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      FixedList<Document> documents = DocumentLink.GetDocumentsFor(entity);

      return DocumentMapper.Map(documents);
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

}  // namespace Empiria.Documents
