/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : General Object                          *
*  Type     : DiscountType                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a discount type.                                                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  public class DiscountType : GeneralObject {

    #region Constructors and parsers

    private DiscountType() {
      // Required by Empiria Framework.
    }

    static public DiscountType Parse(int id) {
      return BaseObject.ParseId<DiscountType>(id);
    }

    static public TaxType Parse(string uid) {
      return BaseObject.ParseKey<TaxType>(uid);
    }

    static public DiscountType Empty => BaseObject.ParseEmpty<DiscountType>();

    #endregion Constructors and parsers

  } // class DiscountType

} // namespace Empiria.Financial
