/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : CreditType                                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes the type of a credit.                                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Describes the type of a credit.</summary>
  public class CreditType : CommonStorage {

    #region Constructors and parsers

    static public CreditType Parse(int id) => ParseId<CreditType>(id);

    static public CreditType Parse(string uid) => ParseKey<CreditType>(uid);

    static public CreditType Empty => ParseEmpty<CreditType>();

    static public FixedList<CreditType> GetList() {
      return GetStorageObjects<CreditType>();
    }

    #endregion Constructors and parsers

  } // class CreditType

} // namespace Empiria.Financial
