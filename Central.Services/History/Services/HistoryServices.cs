/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : History                                   Component : Services Layer                           *
*  Assembly : Empiria.Central.Services.dll              Pattern   : Services provider                        *
*  Type     : HistoryServices                           License   : Please read LICENSE.txt file             *
*                                                                                                            *
*  Summary  : Services for History instances.                                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.History.Services.Adapters;

namespace Empiria.History.Services {

  /// <summary>Services for History instances.</summary>
  static public class HistoryServices {

    #region Services

    static public FixedList<HistoryDto> GetEntityHistory(BaseObject entity) {
      Assertion.Require(entity, nameof(entity));

      return new FixedList<HistoryDto>();
    }

    #endregion Services

  }  // class HistoryServices

}  // namespace Empiria.History.Services
