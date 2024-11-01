/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : SATMoneda                                  License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Moneda de acuerdo al catálogo del SAT México para facturación electrónica.                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.Financial;

namespace Empiria.Products.SATMexico {

  /// <summary>Moneda de acuerdo al catálogo del SAT México para facturación electrónica.</summary>
  public class SATMoneda : SATDataItem {

    #region Constructors and parsers

    static public SATMoneda Parse(int id) => ParseId<SATMoneda>(id);

    static public SATMoneda Parse(string uid) => ParseKey<SATMoneda>(uid);

    static public FixedList<SATMoneda> GetList() {
      return BaseObject.GetList<SATMoneda>()
                       .ToFixedList();
    }

    public static SATMoneda ParseWithCode(string code) {
      var monedaSAT = TryParse<SATMoneda>($"SAT_DATA_ITEM_CODE = '{code}'");

      Assertion.Require(monedaSAT, $"La moneda '{code}' no ha sido registrada en el catálogo del SAT.");

      return monedaSAT;
    }

    static public SATMoneda Empty => ParseEmpty<SATMoneda>();

    #endregion Constructors and parsers

    #region Properties

    public Currency Currency {
      get {
        return base.ExtData.Get("currencyId", Currency.Empty);
      }
    }

    #endregion Properties


  } // class SATMoneda

} // namespace Empiria.Products.SATMexico
