/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : History Services                          Component : Services Layer                           *
*  Assembly : Empiria.Central.Services.dll              Pattern   : Services provider                        *
*  Type     : HistoryServices                           License   : Please read LICENSE.txt file             *
*                                                                                                            *
*  Summary  : Provides services for object's history.                                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.History.Data;

using Empiria.History.Services.Adapters;

namespace Empiria.History.Services {

  /// <summary>Provides services for object's history.</summary>
  static public class HistoryServices {

    #region Services

    static public HistoryEntryDto CreateHistoryEntry(BaseObject entity, HistoryFields data) {
      Assertion.Require(entity, nameof(entity));
      Assertion.Require(data, nameof(data));

      var entry = new HistoryEntry(entity, data);

      entry.Save();

      return HistoryEntryMapper.Map(entry);
    }


    static public FixedList<HistoryEntryDto> GetEntityHistory(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      FixedList<HistoryEntry> history = HistoryData.GetHistory(entity);

      return HistoryEntryMapper.Map(history);
    }

    #endregion Services

  }  // class HistoryServices

}  // namespace Empiria.History.Services
