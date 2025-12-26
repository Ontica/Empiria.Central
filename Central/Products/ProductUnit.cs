/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : ProductUnit                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a product or service unit of measure.                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products {

  /// <summary>Represents a product or service unit of measure.</summary>
  public class ProductUnit : CommonStorage {

    #region Constructors and parsers

    static public ProductUnit Parse(int id) => ParseId<ProductUnit>(id);

    static public ProductUnit Parse(string uid) => ParseKey<ProductUnit>(uid);

    static public ProductUnit Empty => ParseEmpty<ProductUnit>();

    static public FixedList<ProductUnit> GetList() {
      return GetStorageObjects<ProductUnit>();
    }

    #endregion Constructors and parsers

    #region Properties

    public string Abbreviation {
      get {
        return ExtData.Get("abbreviation", string.Empty);
      }
      private set {
        ExtData.SetIfValue("abbreviation", value);
      }
    }


    public bool MoneyBased {
      get {
        return ExtData.Get("moneyBased", false);
      }
      private set {
        ExtData.SetIf("moneyBased", value, value == true);
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(Name, Abbreviation);
      }
    }

    #endregion Properties

  } // class ProductUnit

} // namespace Empiria.Products
