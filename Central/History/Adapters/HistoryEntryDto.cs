/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : History Services                           Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Output DTO                              *
*  Type     : HistoryEntryDto                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for History entry instances.                                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.History {

  // <summary>Output DTO for History entry instances.</summary>
  public class HistoryEntryDto {

    public string UID {
      get; internal set;
    }

    public string Operation {
      get; internal set;
    }

    public string PartyName {
      get; internal set;
    }

    public string Description {
      get; internal set;
    }

    public DateTime Time {
      get; internal set;
    }

  } // HistoryEntryDto

}  // namespace Empiria.History
