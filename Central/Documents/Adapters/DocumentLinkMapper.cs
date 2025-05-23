﻿/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Mapper                                  *
*  Type     : DocumentLinkMapper                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides mapping services for Document instances.                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Documents {

  /// <summary>Provides mapping services for Document instances.</summary>
  static internal class DocumentLinkMapper {


    static internal FixedList<DocumentLinkDto> Map(FixedList<DocumentLink> links) {
      return links.Select(x => Map(x))
                  .ToFixedList();
    }

    static internal DocumentLinkDto Map(DocumentLink link) {
      return new DocumentLinkDto {

      };
    }

  }  // class DocumentLinkMapper

} // namespace Empiria.Documents
