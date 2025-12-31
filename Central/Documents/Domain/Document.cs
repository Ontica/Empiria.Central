/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Partitioned type                        *
*  Type     : Document                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Partitioned type that represents a document.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using System.IO;

using Empiria.Json;
using Empiria.Ontology;
using Empiria.Parties;
using Empiria.StateEnums;
using Empiria.Storage;

namespace Empiria.Documents {

  /// <summary>Partitioned type that represents a document.</summary>
  [PartitionedType(typeof(DocumentType))]
  internal class Document : BaseObject, INamedEntity {

    #region Constructors and parsers

    protected Document(DocumentType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    internal protected Document(DocumentProduct documentProduct,
                                BaseObject baseEntity,
                                FileData fileData,
                                string name) : base(DocumentType.Empty) {

      Assertion.Require(baseEntity, nameof(baseEntity));
      Assertion.Require(fileData, nameof(fileData));
      name = EmpiriaString.Clean(name);
      Assertion.Require(name, nameof(name));

      DocumentCategory = documentProduct.ProductCategory;
      Name = name;
      BaseEntityTypeId = baseEntity.GetEmpiriaType().Id;
      BaseEntityId = baseEntity.Id;
      FileLocation = DocumentCategory.FileLocation;
      _documentFileData = fileData.ToString();
    }

    static public Document Parse(int id) => ParseId<Document>(id);

    static public Document Parse(string uid) => ParseKey<Document>(uid);

    static internal FixedList<Document> GetListFor(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      return BaseObject.GetFullList<Document>()
                       .ToFixedList()
                       .FindAll(x => x.BaseEntityId == entity.Id &&
                                     x.BaseEntityTypeId == entity.GetEmpiriaType().Id &&
                                     x.Status != EntityStatus.Deleted);
    }

    static public Document Empty => ParseEmpty<Document>();

    #endregion Constructors and parsers

    #region Properties

    public DocumentType DocumentType {
      get {
        return (DocumentType) base.GetEmpiriaType();
      }
    }


    [DataField("DOCUMENT_CATEGORY_ID")]
    public DocumentCategory DocumentCategory {
      get;
      private set;
    }


    [DataField("DOCUMENT_PRODUCT_ID")]
    public DocumentProduct DocumentProduct {
      get;
      private set;
    }


    [DataField("DOCUMENT_NO")]
    public string DocumentNumber {
      get;
      private set;
    }


    [DataField("DOCUMENT_NAME")]
    public string Name {
      get;
      private set;
    }


    [DataField("DOCUMENT_DESCRIPTION")]
    public string Description {
      get;
      private set;
    }


    [DataField("DOCUMENT_IDENTIFIERS")]
    private string _identifiers = string.Empty;

    public FixedList<string> Identifiers {
      get {
        return EmpiriaString.Tagging(_identifiers);
      }
    }


    [DataField("DOCUMENT_TAGS")]
    private string _tags = string.Empty;

    public FixedList<string> Tags {
      get {
        return EmpiriaString.Tagging(_tags);
      }
    }


    [DataField("DOCUMENT_SOURCE_PARTY_ID")]
    public Party SourceParty {
      get;
      private set;
    }


    [DataField("DOCUMENT_TARGET_PARTY_ID")]
    public Party TargetParty {
      get;
      private set;
    }


    [DataField("DOCUMENT_SIGNED_BY_ID")]
    public Person SignedBy {
      get;
      private set;
    }


    [DataField("DOCUMENT_DATE")]
    public DateTime DocumentDate {
      get;
      private set;
    }


    [DataField("DOCUMENT_BASE_ENTITY_TYPE_ID")]
    internal int BaseEntityTypeId {
      get;
      private set;
    }


    [DataField("DOCUMENT_BASE_ENTITY_ID")]
    internal int BaseEntityId {
      get;
      private set;
    }


    [DataField("DOCUMENT_FILE_LOCATION_ID")]
    public FileLocation FileLocation {
      get;
      private set;
    }


    [DataField("DOCUMENT_FILE_DATA")]
    private string _documentFileData = string.Empty;

    public FileData FileData {
      get {
        return FileData.Parse(_documentFileData);
      }
    }


    [DataField("DOCUMENT_EXT_DATA")]
    protected internal JsonObject ExtensionData {
      get;
      private set;
    }


    internal int HistoricId {
      get {
        return this.Id;
      }
    }

    [DataField("DOCUMENT_LAST_UPDATE_TIME")]
    public DateTime LastUpdateTime {
      get;
      private set;
    }


    [DataField("DOCUMENT_POSTED_BY_ID")]
    public Party PostedBy {
      get;
      private set;
    }


    [DataField("DOCUMENT_POSTING_TIME")]
    public DateTime PostingTime {
      get;
      private set;
    }


    [DataField("DOCUMENT_STATUS", Default = EntityStatus.Active)]
    public EntityStatus Status {
      get;
      private set;
    }


    public decimal Total {
      get {
        return ExtensionData.Get("total", 0m);
      }
      private set {
        ExtensionData.SetIf("total", value, value != 0);
      }
    }


    protected internal virtual string Keywords {
      get {
        return EmpiriaString.BuildKeywords(DocumentNumber, Name,
                                           DocumentType.DisplayName, Description);
      }
    }

    public string FullLocalName {
      get {
        return FileLocation.GetFileFullLocalName(this.FileData);
      }
    }

    #endregion Properties

    #region Methods

    internal void Delete() {
      Status = EntityStatus.Deleted;
      LastUpdateTime = DateTime.Now;
    }


    internal FileDto FileDto() {
      var url = $"{FileLocation.BaseUrl}/{FileData.FileName}";

      return new FileDto(FileData.FileType, url);
    }


    internal BaseObject GetBaseEntity() {
      return Parse(BaseEntityTypeId, BaseEntityId);
    }


    internal T GetBaseEntity<T>() where T : BaseObject {
      return (T) GetBaseEntity();
    }


    protected override void OnSave() {
      if (this.IsNew) {
        PostedBy = Party.ParseWithContact(ExecutionServer.CurrentContact);
        PostingTime = DateTime.Now;
        LastUpdateTime = PostingTime;
      } else {
        LastUpdateTime = DateTime.Now;
      }

      DocumentDataService.WriteDocument(this);
    }


    public string ReadAllText() {
      return File.ReadAllText(this.FullLocalName);
    }

    internal void Update(DocumentFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      DocumentProduct = Patcher.Patch(fields.DocumentProductUID, DocumentProduct);
      DocumentNumber = Patcher.PatchClean(fields.DocumentNumber, DocumentNumber);
      Name = Patcher.PatchClean(fields.Name, Name);
      Description = Patcher.PatchClean(fields.Description, Description);
      DocumentDate = Patcher.Patch(fields.DocumentDate, DocumentDate);

      _tags = EmpiriaString.Tagging(fields.Tags);

      SourceParty = Patcher.Patch(fields.SourcePartyUID, SourceParty);
      TargetParty = Patcher.Patch(fields.TargetPartyUID, TargetParty);
      SignedBy = Patcher.Patch(fields.SignedByUID, SignedBy);

      Total = fields.Total;
    }


    #endregion Methods

  } // class Document

}  // namespace Empiria.Documents
