/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Parties                                    Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Partitioned Type                        *
*  Type     : Party                                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Abstract partitioned type that represents a person, an organization, an organizational unit,   *
*             a group or a team, that can play one or more roles in parties relationships.                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Json;
using Empiria.Ontology;
using Empiria.StateEnums;

using Empiria.Parties.Data;

namespace Empiria.Parties {

  /// <summary>Abstract partitioned type that represents a person, an organization, an organizational unit
  ///  a group or a team, that can play one or more roles in parties relationships.</summary>
  [PartitionedType(typeof(PartyType))]
  public abstract class Party : BaseObject, IHistoricObject, INamedEntity {

    static private int PRIMARY_PARTY_ID = ConfigurationData.Get("PrimaryPartyId", 1);

    #region Constructors and parsers

    protected Party() {
      // Required by Empiria Framework.
    }

    protected Party(PartyType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    static public Party Parse(int id) {
      return BaseObject.ParseId<Party>(id);
    }


    static public Party Parse(string uid) {
      return BaseObject.ParseKey<Party>(uid);
    }


    static public Party ParseWithContact(Contacts.Contact contact) {
      var party = BaseObject.TryParse<Party>($"PARTY_CONTACT_ID = {contact.Id}");

      Assertion.Require(party, $"A party associated with Contact {contact.Id} was not found.");

      return party;
    }


    static public FixedList<T> GetList<T>(DateTime date) where T : Party {
      return PartyDataService.GetPartiesInDate<T>(date);
    }


    static public FixedList<Party> GetPartiesInRole(string roleName) {
      return GetList<Party>($"PARTY_TAGS LIKE '%{roleName}%'")
            .ToFixedList()
            .Sort((x, y) => x.Name.CompareTo(y.Name));
    }


    public static Party TryParseWithID(string partyID) {
      return TryParse<Party>($"PARTY_TAGS LIKE '%{partyID}%'");
    }

    static public Party Empty => ParseEmpty<Person>();

    static public Party Primary => Parse(PRIMARY_PARTY_ID);

    #endregion Constructors and parsers

    #region Properties

    public PartyType PartyType {
      get {
        return (PartyType) base.GetEmpiriaType();
      }
    }


    [DataField("PARTY_NAME")]
    public string Name {
      get; private set;
    }


    [DataField("PARTY_TAGS")]
    private string _tags = string.Empty;

    public FixedList<string> Tags {
      get {
        return _tags.Split(' ').ToFixedList();
      }
    }

    [DataField("PARTY_EXT_DATA")]
    protected internal JsonObject ExtendedData {
      get; private set;
    }


    public virtual string Keywords {
      get {
        return EmpiriaString.BuildKeywords(Name);
      }
    }


    [DataField("PARTY_HISTORIC_ID")]
    public int HistoricId {
      get; private set;
    }


    [DataField("PARTY_START_DATE")]
    internal DateTime StartDate {
      get; private set;
    }


    [DataField("PARTY_END_DATE")]
    internal DateTime EndDate {
      get; private set;
    }


    [DataField("PARTY_POSTED_BY_ID")]
    internal int PostedById {
      get; private set;
    }


    [DataField("PARTY_POSTING_TIME")]
    internal DateTime PostingTime {
      get; private set;
    }


    [DataField("PARTY_STATUS", Default = EntityStatus.Active)]
    public EntityStatus Status {
      get; private set;
    }


    [DataField("PARTY_CONTACT_ID")]
    public Contacts.Contact Contact {
      get; private set;
    }

    #endregion Properties

    #region Methods

    public void ChangeStatus(EntityStatus status) {
      this.Status = status;
    }


    protected override void OnSave() {
      if (base.IsNew) {
        HistoricId = this.Id;
        PostedById = ExecutionServer.CurrentUserId;
        PostingTime = DateTime.Now;
        EndDate = ExecutionServer.DateMaxValue;
      }
      PartyDataService.WriteParty(this);
    }


    internal void SaveHistoric(IHistoricObject historyOf) {
      Assertion.Require(base.IsNew, "Can't save already living instances as historic.");

      this.HistoricId = historyOf.HistoricId;
      PostedById = ExecutionServer.CurrentUserId;
      PostingTime = DateTime.Now;

      PartyDataService.CloseHistoricParty(historyOf);
      PartyDataService.WriteParty(this);
    }


    protected void Update(PartyFields fields) {
      this.Name = PatchCleanField(fields.Name, this.Name);
      this.StartDate = fields.StartDate == ExecutionServer.DateMaxValue ? StartDate : fields.StartDate;
    }

    #endregion Methods

  } // class Party

} // namespace Empiria.Parties
