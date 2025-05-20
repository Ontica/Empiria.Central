/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : History Services                           Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Value type, Input Fields DTO            *
*  Type     : HistoryFields                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Value type with input fields usted to create history instances.                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.History {

  // <summary>Value type with input fields usted to create history instances.</summary>
  public class HistoryFields {

    #region Constructors and parsers

    public HistoryFields(string operation) :
              this(Party.ParseWithContact(ExecutionServer.CurrentContact), operation, "S/D") {
      // no-op
    }

    public HistoryFields(string operation, string description) :
              this(Party.ParseWithContact(ExecutionServer.CurrentContact), operation, description) {
      // no-op
    }

    public HistoryFields(Party party, string operation, string description) {
      Assertion.Require(party, nameof(party));
      Assertion.Require(!party.IsEmptyInstance, "Party can not be the empty instance.");
      Assertion.Require(operation, nameof(operation));
      Assertion.Require(description, nameof(description));

      Party = party;
      Operation = operation;
      Description = description;
    }

    #endregion Constructors and parsers

    #region Properties

    public Party Party {
      get;
    }

    public string Operation {
      get;
    }

    public string Description {
      get;
    }

    #endregion Properties

  } // HistoryFields

}  // namespace Empiria.History
