/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : CreditRiskStage                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes the risk stage of a credit.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Describes the risk stage of a credit.</summary>
  public class CreditRiskStage : CommonStorage {

    #region Constructors and parsers

    static public CreditRiskStage Parse(int id) => ParseId<CreditRiskStage>(id);

    static public CreditRiskStage Parse(string uid) => ParseKey<CreditRiskStage>(uid);

    static public CreditRiskStage Empty => ParseEmpty<CreditRiskStage>();

    static public FixedList<CreditRiskStage> GetList() {
      return GetStorageObjects<CreditRiskStage>();
    }

    #endregion Constructors and parsers

  } // class CreditRiskStage

} // namespace Empiria.Financial
