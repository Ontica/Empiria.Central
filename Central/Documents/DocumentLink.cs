/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.Core.dll                   Pattern   : Information Holder                      *
*  Type     : DocumentLink                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a link between a document and another entity.                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using System.Linq;

using Empiria.Json;
using Empiria.Ontology;
using Empiria.Parties;
using Empiria.Reflection;
using Empiria.StateEnums;

namespace Empiria.Documents {

  /// <summary>Represents a link between a document and another entity.</summary>
  public class DocumentLink : BaseObject {

    #region Constructors and parsers

    private DocumentLink() {
      // Required by Empiria Framework.
    }


    internal DocumentLink(DocumentLinkType linkType, Document document, BaseObject linkedEntity) {
      Assertion.Require(linkType, nameof(linkType));
      Assertion.Require(document, nameof(document));
      Assertion.Require(linkedEntity, nameof(linkedEntity));

      Assertion.Require(!linkType.IsEmptyInstance,
                        "linkType can not be the empty instance.");
      Assertion.Require(!document.IsEmptyInstance,
                        "document can not be the empty instance.");
      Assertion.Require(!linkedEntity.IsEmptyInstance,
                        "linkedObject can not be the empty instance.");

      Assertion.Require(linkedEntity.GetEmpiriaType().Equals(linkType.LinkedObjectType),
                       "linkedObject mismatch.");

      this.DocumentLinkType = linkType;
      this.Document = document;
      this.LinkedEntityTypeId = linkedEntity.GetEmpiriaType().Id;
      this.LinkedEntityId = linkedEntity.Id;
    }


    internal DocumentLink(Document document, BaseObject linkedEntity) {
      Assertion.Require(document, nameof(document));
      Assertion.Require(linkedEntity, nameof(linkedEntity));

      Assertion.Require(!document.IsEmptyInstance,
                        "document can not be the empty instance.");
      Assertion.Require(!linkedEntity.IsEmptyInstance,
                        "linkedObject can not be the empty instance.");

      this.DocumentLinkType = DocumentLinkType.Empty;
      this.Document = document;
      this.LinkedEntityTypeId = linkedEntity.GetEmpiriaType().Id;
      this.LinkedEntityId = linkedEntity.Id;
    }


    static internal DocumentLink Parse(int id) => ParseId<DocumentLink>(id);

    static internal DocumentLink Parse(string UID) {
      return ParseKey<DocumentLink>(UID);
    }


    static public FixedList<BaseObject> GetEntitiesFor(Document document) {
      return BaseObject.GetFullList<DocumentLink>()
                       .ToFixedList()
                       .FindAll(x => x.Document.Equals(document))
                       .Select(x => x.GetLinkedEntity())
                       .Distinct()
                       .ToFixedList();
    }


    static public FixedList<Document> GetDocumentsFor(BaseObject linkedEntity) {
      return BaseObject.GetFullList<DocumentLink>()
                       .ToFixedList()
                       .FindAll(x => x.GetLinkedEntity().Equals(linkedEntity))
                       .Select(x => x.Document)
                       .Distinct()
                       .ToFixedList();
    }


    static public FixedList<DocumentLink> GetListFor(Document document) {
      return BaseObject.GetFullList<DocumentLink>()
                       .ToFixedList()
                       .FindAll(x => x.Document.Equals(document));
    }

    static public DocumentLink Empty => ParseEmpty<DocumentLink>();

    #endregion Constructors and parsers

    #region Properties

    [DataField("DOCUMENT_LINK_TYPE_ID")]
    public DocumentLinkType DocumentLinkType {
      get; private set;
    }


    [DataField("DOCUMENT_ID")]
    public Document Document {
      get; private set;
    }


    [DataField("DOCUMENT_LINKED_ENTITY_TYPE_ID")]
    internal int LinkedEntityTypeId {
      get; private set;
    }


    [DataField("DOCUMENT_LINKED_ENTITY_ID")]
    internal int LinkedEntityId {
      get; private set;
    }


    [DataField("DOCUMENT_LINKED_ENTITY_ROLE")]
    internal string LinkedEntityRole {
      get; private set;
    }


    [DataField("DOCUMENT_LINK_IDENTIFICATORS")]
    public string Identificators {
      get; private set;
    }

    [DataField("DOCUMENT_LINK_TAGS")]
    public string Tags {
      get; private set;
    }

    [DataField("DOCUMENT_LINK_EXT_DATA")]
    internal JsonObject ExtensionData {
      get; private set;
    }


    [DataField("DOCUMENT_LINK_POSTED_BY_ID")]
    public Party PostedBy {
      get; private set;
    }


    [DataField("DOCUMENT_LINK_POSTING_TIME")]
    public DateTime PostingTime {
      get; private set;
    }


    [DataField("DOCUMENT_LINK_STATUS", Default = EntityStatus.Active)]
    public EntityStatus Status {
      get; private set;
    }


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(Document.Keywords);
      }
    }

    #endregion Properties

    #region Methods

    internal void Delete() {
      this.Status = EntityStatus.Deleted;
    }


    protected override void OnSave() {
      if (base.IsNew) {
        this.PostedBy = Party.ParseWithContact(ExecutionServer.CurrentContact);
        this.PostingTime = DateTime.Now;
      }
      DocumentDataService.WriteDocumentLink(this);
    }


    internal BaseObject GetLinkedEntity() {
      ObjectTypeInfo typeInfo = ObjectTypeInfo.Parse(LinkedEntityTypeId);

      return (BaseObject) ObjectFactory.InvokeParseMethod(typeInfo.UnderlyingSystemType,
                                                          LinkedEntityId);
    }


    internal T GetLinkedEntity<T>() where T : BaseObject {
      return (T) GetLinkedEntity();
    }


    internal void Update(DocumentLinkFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      LinkedEntityRole = PatchCleanField(fields.LinkedEntityRole, LinkedEntityRole);
    }

    #endregion Methods

  }  // class DocumentLink

}  // namespace Empiria.Documents
