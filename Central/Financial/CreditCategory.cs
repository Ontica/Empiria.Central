/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : CreditCategory                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Categorizes the purpose of a credit.                                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Categorizes the purpose of a credit.</summary>
  public class CreditCategory : CommonStorage {

    #region Constructors and parsers

    static public CreditCategory Parse(int id) => ParseId<CreditCategory>(id);

    static public CreditCategory Parse(string uid) => ParseKey<CreditCategory>(uid);

    static public CreditCategory Empty => ParseEmpty<CreditCategory>();

    static public FixedList<CreditCategory> GetList() {
      return GetStorageObjects<CreditCategory>();
    }

    #endregion Constructors and parsers

  } // class CreditCategory

} // namespace Empiria.Financial
