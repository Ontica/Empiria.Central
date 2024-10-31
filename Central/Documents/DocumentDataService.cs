/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Data Access Layer                       *
*  Assembly : Empiria.Central.dll                        Pattern   : Data service                            *
*  Type     : DocumentDataService                        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides documents data persistence services.                                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.Data;

namespace Empiria.Documents {

  /// <summary>Provides documents data persistence services.</summary>
  static internal class DocumentDataService {

    static internal FixedList<Document> SearchDocuments(string filter, string sort) {
      Assertion.Require(filter, nameof(filter));
      Assertion.Require(sort, nameof(sort));

      var sql = "SELECT * FROM DOCUMENTS " +
               $"WHERE {filter} " +
               $"ORDER BY {sort}";

      var op = DataOperation.Parse(sql);

      return DataReader.GetFixedList<Document>(op);
    }


    static internal void WriteDocument(Document o) {
      var op = DataOperation.Parse("write_Document", o.Id, o.UID,
                  o.DocumentType.Id, o.DocumentCategory.Id, o.DocumentProduct.Id,
                  o.DocumentNo, o.Name, o.Description, string.Join(" ", o.Tags),
                  string.Join(" ", o.Identifiers), o.SourceParty.Id, o.TargetParty.Id,
                  o.SignedBy.Id, o.DocumentDate, o.BaseEntityTypeId, o.BaseEntityId,
                  o.FileLocation.Id, o.FileData.ToString(), o.ExtensionData.ToString(), o.Keywords,
                  o.HistoricId, o.LastUpdateTime, o.PostedBy.Id, o.PostingTime, (char) o.Status);

      DataWriter.Execute(op);
    }


    static internal void WriteDocumentLink(DocumentLink o) {
      var op = DataOperation.Parse("write_Document_Link", o.Id, o.UID,
          o.DocumentLinkType.Id, o.Document.Id, o.LinkedEntityTypeId, o.LinkedEntityId,
          o.LinkedEntityRole, o.Identificators, o.Tags, o.ExtensionData.ToString(),
          o.Keywords, o.PostedBy.Id, o.PostingTime, (char) o.Status);

      DataWriter.Execute(op);
    }

  }  // class DocumentDataService

}  // namespace Empiria.Documents
