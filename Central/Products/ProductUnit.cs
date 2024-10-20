/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : ProductUnit                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a product or service unit of measure.                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products {

  /// <summary>Represents a product or service unit of measure.</summary>
  public class ProductUnit : GeneralObject {

    #region Constructors and parsers

    static public ProductUnit Parse(int id) => ParseId<ProductUnit>(id);

    static public ProductUnit Parse(string uid) => ParseKey<ProductUnit>(uid);

    static public FixedList<ProductUnit> GetList() {
      return BaseObject.GetList<ProductUnit>()
                       .ToFixedList();
    }

    static public ProductUnit Empty => ParseEmpty<ProductUnit>();

    #endregion Constructors and parsers

    #region Properties

    public string Abbreviation {
      get {
        return base.ExtendedDataField.Get("abbreviation", string.Empty);
      }
      private set {
        base.ExtendedDataField.SetIfValue("abbreviation", value);
      }
    }


    public FixedList<string> SATCodes {
      get {
        return base.ExtendedDataField.GetFixedList<string>("SATCodes", false);
      }
      private set {
        base.ExtendedDataField.SetIfValue("SATCodes", value);
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
