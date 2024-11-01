/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Output DTO                              *
*  Type     : DocumentDto                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for Document instances.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

namespace Empiria.History.Services.Adapters {

  // <summary>Output DTO used to return minimal history information about payables.</summary>
  public class HistoryDto {

    public string UID {
      get; internal set;
    }


    public string Type {
      get; internal set;
    }


    public string Description {
      get; internal set;
    }


    public DateTime Time {
      get; internal set;
    }


    public NamedEntityDto Party {
      get; internal set;
    }

  } // HistoryDto

}  // namespace Empiria.DocumentDto.Services.Adapters
