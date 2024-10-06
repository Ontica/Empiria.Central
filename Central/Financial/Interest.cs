/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Value Type                              *
*  Type     : Interest                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Contains data about a financial interest rate and term.                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Json;
using Empiria.Measurement;

namespace Empiria.Financial {

  /// <summary>Contains data about a financial interest rate and term.</summary>
  public class Interest {

    #region Constructors and parsers

    public Interest() {
      this.Rate = 0.0000m;
      this.RateType = InterestRateType.Empty;
      this.TermPeriods = 0;
      this.TermUnit = TimeUnit.Unknown;
    }


    static public Interest Parse(JsonObject json) {
      var interest = new Interest();

      interest.TermPeriods = json.Get("TermPeriods", interest.TermPeriods);
      interest.TermUnit = json.Get("TermUnitId", interest.TermUnit);
      interest.Rate = json.Get("InterestRate", interest.Rate);
      interest.RateType = json.Get("InterestRateTypeId", interest.RateType);

      return interest;
    }

    static public Interest Empty {
      get {
        return new Interest() {
          IsEmptyInstance = true
        };
      }
    }

    #endregion Constructors and parsers

    #region Properties

    public bool IsEmptyInstance {
      get;
      private set;
    }

    public decimal Rate {
      get;
      set;
    }

    public InterestRateType RateType {
      get;
      set;
    }

    public int TermPeriods {
      get;
      set;
    }

    public TimeUnit TermUnit {
      get;
      set;
    }

    #endregion Properties

    #region Methods

    public string ToJson() {
      return JsonConverter.ToJson(this);
    }

    #endregion Methods

  }  // class Interest

} // namespace Empiria.Financial
