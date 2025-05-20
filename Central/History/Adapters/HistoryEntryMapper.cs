/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : History Services                          Component : Adapters Layer                           *
*  Assembly : Empiria.Central.dll                       Pattern   : Mapper                                   *
*  Type     : HistoryEntryMapper                        License   : Please read LICENSE.txt file             *
*                                                                                                            *
*  Summary  : Provides adapter's mapping services for object's history entries.                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.History {

  /// <summary>Provides adapter's mapping services for object's history entries.</summary>
  static internal class HistoryEntryMapper {


    static internal FixedList<HistoryEntryDto> Map(FixedList<HistoryEntry> history) {
      return history.Select(x => Map(x))
                    .ToFixedList();
    }


    static internal HistoryEntryDto Map(HistoryEntry entry) {
      return new HistoryEntryDto {
        UID = entry.UID,
        Operation = entry.Operation,
        Description = entry.Description,
        PartyName = entry.Party.Name,
        Time = entry.TimeStamp
      };
    }

  }  // class HistoryEntryMapper

}  // namespace Empiria.History
