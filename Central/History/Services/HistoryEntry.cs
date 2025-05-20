/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : History Services                          Component : Domain Layer                             *
*  Assembly : Empiria.Central.dll                       Pattern   : Information Holder                       *
*  Type     : HistoryEntry                              License   : Please read LICENSE.txt file             *
*                                                                                                            *
*  Summary  : Holds information about an object's history entry.                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Json;
using Empiria.Parties;

namespace Empiria.History {

  /// <summary>Holds information about an object's history entry.</summary>
  internal class HistoryEntry : BaseObject {

    #region Constructors and parsers

    private HistoryEntry() {
      // Required by Empiria Framework
    }

    internal HistoryEntry(BaseObject entryObject, HistoryFields data) {
      Assertion.Require(entryObject, nameof(entryObject));
      Assertion.Require(data, nameof(data));

      ObjectId = entryObject.Id;
      ObjectTypeId = entryObject.GetEmpiriaType().Id;
      ObjectTypeTag = entryObject.GetEmpiriaType().ReclassificationTag;
      Operation = data.Operation;
      Description = data.Description;
      Party = data.Party;
      TimeStamp = DateTime.Now;
      UserSessionId = ExecutionServer.CurrentSessionId;
    }

    static public HistoryEntry Parse(int id) => ParseId<HistoryEntry>(id);

    static public HistoryEntry Parse(string uid) => ParseKey<HistoryEntry>(uid);

    #endregion Constructors and parsers

    #region Properties

    [DataField("HIST_ENTRY_OBJECT_ID")]
    internal int ObjectId {
      get; private set;
    }


    [DataField("HIST_ENTRY_OBJECT_TYPE_ID")]
    internal int ObjectTypeId {
      get; private set;
    }


    [DataField("HIST_ENTRY_OBJECT_TYPE_TAG")]
    internal string ObjectTypeTag {
      get; private set;
    }


    [DataField("HIST_ENTRY_OPERATION")]
    internal string Operation {
      get; private set;
    }


    [DataField("HIST_ENTRY_DESCRIPTION")]
    internal string Description {
      get; private set;
    }


    [DataField("HIST_ENTRY_EXT_DATA")]
    internal JsonObject ExtData {
      get; private set;
    }


    [DataField("HIST_ENTRY_PARTY_ID")]
    internal Party Party {
      get; private set;
    }


    [DataField("HIST_ENTRY_TIMESTAMP")]
    internal DateTime TimeStamp {
      get; private set;
    }


    [DataField("HIST_ENTRY_USER_SESSION_ID")]
    internal int UserSessionId {
      get; private set;
    }

    #endregion Properties

    #region Methods

    protected override void OnSave() {
      if (this.IsNew) {
        HistoryDataService.Write(this);
      }
    }

    #endregion Methods

  }  // class HistoryEntry

}  // namespace Empiria.History
