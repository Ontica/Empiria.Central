/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : TaxType                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a tax type.                                                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Products;

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

    static public FixedList<TaxType> AppliableFor(Product product) {
      return GetList().FindAll(x => x.ProductAppliable);
    }

    #endregion Constructors and parsers

    #region Properties

    public bool IsBudgetable {
      get {
        return ExtData.Get("isBudgetable", false);
      }
    }


    public bool IsForControl {
      get {
        return ExtData.Get("isForControl", false);
      }
    }


    public bool ProductAppliable {
      get {
        return ExtData.Get("productAppliable", false);
      }
    }


    public decimal Rate {
      get {
        return ExtData.Get("rate", decimal.Zero);
      }
    }

    #endregion Properties
  } // class TaxType

} // namespace Empiria.Financial
