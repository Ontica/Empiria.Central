/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : General Object                          *
*  Type     : Currency                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a currency data type.                                                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Represents a currency data type.</summary>
  public class Currency : GeneralObject {

    #region Fields

    static readonly int defaultCurrencyId = ConfigurationData.Get<int>("Default.Currency.Id", -1);

    #endregion Fields

    #region Constructors and parsers

    private Currency() {
      // Required by Empiria Framework.
    }

    static public Currency Parse(int id) {
      return BaseObject.ParseId<Currency>(id);
    }

    static public Currency Parse(string uid) {
      return BaseObject.ParseKey<Currency>(uid);
    }

    static public Currency Default {
      get { return Currency.Parse(defaultCurrencyId); }
    }

    static public Currency Empty => BaseObject.ParseEmpty<Currency>();

    #endregion Constructors and parsers

    #region Properties

    public string Abbreviation {
      get { return base.NamedKey; }
    }


    public bool HasSymbol {
      get {
        return !string.IsNullOrEmpty(Symbol);
      }
    }


    public string Symbol {
      get {
        return base.ExtendedDataField.Get<string>("symbol", string.Empty);
      }
    }

    #endregion Properties

    #region Methods

    public string Format(decimal amount) {
      if (HasSymbol) {
        return $"{Symbol}{amount.ToString("#,##0.00")} {Name}";
      } else {
        return $"{amount.ToString("#,##0.####")} {Name}";
      }
    }

    #endregion Methods

  } // class Currency

} // namespace Empiria.Financial
