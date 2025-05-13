/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : History Services                          Component : Data Layer                               *
*  Assembly : Empiria.Central.Services.dll              Pattern   : Data access services provider            *
*  Type     : HistoryData                               License   : Please read LICENSE.txt file             *
*                                                                                                            *
*  Summary  : Persistance services for object's history entries.                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;

namespace Empiria.History.Data {

  /// <summary>Persistance services for object's history entries.</summary>
  static internal class HistoryData {

    static internal FixedList<HistoryEntry> GetHistory(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      string typeFilter = string.Empty;

      if (entity.GetEmpiriaType().ReclassificationTag.Length == 0) {
        typeFilter = $"HIST_ENTRY_OBJECT_TYPE_ID = {entity.GetEmpiriaType().Id}";
      } else {
        typeFilter = $"HIST_ENTRY_OBJECT_TYPE_TAG = '{entity.GetEmpiriaType().ReclassificationTag}'";
      }

      var sql = "SELECT * FROM HISTORY_ENTRIES " +
                $"WHERE HIST_ENTRY_OBJECT_ID = {entity.Id} AND " +
                $"{typeFilter} " +
                $"ORDER BY HIST_ENTRY_TIMESTAMP";

      var op = DataOperation.Parse(sql);

      return DataReader.GetFixedList<HistoryEntry>(op);
    }


    static internal void Write(HistoryEntry o) {
      var op = DataOperation.Parse("apd_History_Entry", o.Id, o.UID,
        o.ObjectId, o.ObjectTypeId, o.ObjectTypeTag,
        o.Operation, o.Description, o.ExtData.ToString(),
        o.Party.Id, o.TimeStamp, o.UserSessionId);

      DataWriter.Execute(op);
    }

  }  // class HistoryData

}  // namespace Empiria.History.Data
