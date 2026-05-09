/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : CreditProcessStage                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes the stage process of a credit.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Describes the stage process of a credit.</summary>
  public class CreditProcessStage : CommonStorage {

    #region Constructors and parsers

    static public CreditProcessStage Parse(int id) => ParseId<CreditProcessStage>(id);

    static public CreditProcessStage Parse(string uid) => ParseKey<CreditProcessStage>(uid);

    static public CreditProcessStage Empty => ParseEmpty<CreditProcessStage>();

    static public FixedList<CreditProcessStage> GetList() {
      return GetStorageObjects<CreditProcessStage>();
    }

    #endregion Constructors and parsers

  } // class CreditProcessStage

} // namespace Empiria.Financial
