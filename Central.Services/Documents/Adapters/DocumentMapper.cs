/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Mapper                                  *
*  Type     : DocumentMapper                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides mapping services for Document instances.                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.StateEnums;

namespace Empiria.Documents.Services.Adapters {

  /// <summary>Provides mapping services for Document instances.</summary>
  static internal class DocumentMapper {

    static internal FixedList<DocumentDto> Map(FixedList<Document> documents) {
      return documents.Select(x => Map(x))
                      .ToFixedList();
    }


    static internal DocumentDto Map(Document document) {
      return new DocumentDto {
        UID = document.UID,
        Name = document.Name,
        Description = document.Description,
        Tags = document.Tags,
        Status = document.Status.MapToDto(),
        FileDto = document.FileDto()
      };
    }


    static internal FixedList<DocumentDescriptorDto> MapToDescriptor(FixedList<Document> documents) {
      return documents.Select(x => MapToDescriptor(x))
                      .ToFixedList();
    }


    #region Helpers

    static private DocumentDescriptorDto MapToDescriptor(Document document) {
      return new DocumentDescriptorDto {
        UID = document.UID,
        Name = document.Name,
        Description = document.Description,
        StatusName = document.Status.GetName(),
        FileDto = document.FileDto()
      };
    }

    #endregion Helpers

  }  // class DocumentMapper

} // namespace Empiria.Documents.Services.Adapters
