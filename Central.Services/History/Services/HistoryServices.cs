/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : DocumentServices                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for Document instances.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.History.Services.Adapters;
using Empiria.Services;

namespace Empiria.History.Services {

  /// <summary>Services for Document instances.</summary>
  public class HistoryServices : Service {

    #region Constructors and parsers

    protected HistoryServices() {
      // no-op
    }

    static public HistoryServices ServiceInteractor() {
      return Service.CreateInstance<HistoryServices>();
    }

    public FixedList<HistoryDto> GetEntityHistory(BaseObject entity) {
      return new FixedList<HistoryDto>();
    }

    #endregion Constructors and parsers

    #region Services

    #endregion Services

  }  // class HistoryServices

}  // namespace Empiria.Documents.Services
