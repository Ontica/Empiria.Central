/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : TaxType                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a tax type.                                                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Represents a tax type.</summary>
  public class TaxType : CommonStorage {

    #region Constructors and parsers

    static public TaxType Parse(int id) => ParseId<TaxType>(id);

    static public TaxType Parse(string uid) => ParseKey<TaxType>(uid);

    static public TaxType Empty => ParseEmpty<TaxType>();

    static public FixedList<TaxType> GetList() {
      return GetStorageObjects<TaxType>();
    }

    #endregion Constructors and parsers

  } // class TaxType

} // namespace Empiria.Financial
