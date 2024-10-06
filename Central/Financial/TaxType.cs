/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : General Object                          *
*  Type     : TaxType                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a tax type.                                                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Represents a tax type.</summary>
  public class TaxType : GeneralObject {

    #region Constructors and parsers

    private TaxType() {
      // Required by Empiria Framework.
    }

    static public TaxType Parse(int id) {
      return BaseObject.ParseId<TaxType>(id);
    }

    static public TaxType Parse(string uid) {
      return BaseObject.ParseKey<TaxType>(uid);
    }

    static public TaxType Empty => BaseObject.ParseEmpty<TaxType>();

    #endregion Constructors and parsers

  } // class TaxType

} // namespace Empiria.Financial
