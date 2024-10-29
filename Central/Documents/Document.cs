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

using Empiria.Json;
using Empiria.Ontology;
using Empiria.Parties;
using Empiria.Products;
using Empiria.StateEnums;

namespace Empiria.Documents {

  /// <summary>Partitioned type that represents a document.</summary>
  [PartitionedType(typeof(DocumentType))]
  public class Document : BaseObject, INamedEntity {

    #region Constructors and parsers

    protected Document(DocumentType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    internal protected Document(DocumentCategory documentCategory, string name) :
                                                       base(documentCategory.DocumentType) {
      DocumentCategory = documentCategory;

      name = EmpiriaString.Clean(name);

      Assertion.Require(name, nameof(name));

      Name = name;

    }

    static public Document Parse(int id) => ParseId<Document>(id);

    static public Document Parse(string uid) => ParseKey<Document>(uid);

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
    public Product DocumentProduct {
      get;
      private set;
    }


    [DataField("DOCUMENT_NO")]
    public string DocumentNo {
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


    [DataField("DOCUMENT_TAGS")]
    private string _tags = string.Empty;

    public FixedList<string> Tags {
      get {
        return _tags.Split(' ').ToFixedList();
      }
    }


    [DataField("DOCUMENT_IDENTIFIERS")]
    private string _identifiers = string.Empty;

    public FixedList<string> Identifiers {
      get {
        return _identifiers.Split(' ').ToFixedList();
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
    public ObjectTypeInfo BaseEntityType {
      get;
      private set;
    }


    [DataField("DOCUMENT_BASE_ENTITY_ID")]
    public BaseObject BaseEntity {
      get;
      private set;
    }


    [DataField("DOCUMENT_FILE_LOCATION_ID")]
    public FileLocation FileLocation {
      get;
      private set;
    }


    [DataField("DOCUMENT_FILE_DATA")]
    public JsonObject FileData {
      get;
      private set;
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



    protected internal virtual string Keywords {
      get {
        return EmpiriaString.BuildKeywords(DocumentNo, Name,
                                           DocumentType.DisplayName, Description);
      }
    }

    #endregion Properties

    #region Methods


    internal void Delete() {
      Status = EntityStatus.Deleted;
      LastUpdateTime = DateTime.Now;
    }


    protected override void OnSave() {
      if (this.IsNew) {
        PostedBy = Party.ParseWithContact(ExecutionServer.CurrentContact);
        PostingTime = DateTime.Today;
      }
      LastUpdateTime = DateTime.Now;
      DocumentDataService.WriteDocument(this);
    }


    internal void Update(ProductFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Name = PatchCleanField(fields.Name, Name);
      Description = PatchCleanField(fields.Description, Description);
      DocumentNo = PatchCleanField(fields.InternalCode, DocumentNo);
      _tags = PatchField(string.Join(" ", fields.Tags), _tags);

    }

    #endregion Methods

  } // class Document

}  // namespace Empiria.Documents
