/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Measurement                                Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Value Type                              *
*  Type     : Quantity                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Value type that handles quantity data, a pair unit-amount data type.                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Measurement {

  /// <summary>Value type that handles quantity data, a pair unit-amount data type.</summary>
  public struct Quantity {

    #region Fields

    private Unit _unit;
    private decimal _amount;

    #endregion Fields

    #region Constructors and parsers

    private Quantity(Quantity quantity) {
      _unit = quantity.Unit;
      _amount = quantity.Amount;
    }


    private Quantity(Unit unit, decimal amount) {
      _unit = unit;
      _amount = amount;
    }


    static public Quantity Parse(Unit unit, decimal amount) {
      return new Quantity(unit, amount);
    }


    static public Quantity One {
      get {
        return new Quantity(Unit.Empty, decimal.One);
      }
    }


    static public Quantity Zero {
      get {
        return new Quantity(Unit.Empty, decimal.Zero);
      }
    }

    #endregion Constructors and parsers

    #region Properties

    public decimal Amount {
      get {
        return _amount;
      }
    }


    public Unit Unit {
      get {
        return _unit;
      }
    }

    #endregion Properties

    #region Operators overloading

    static public Quantity operator +(Quantity quantityA, Quantity quantityB) {
      Quantity temp = new Quantity(quantityA);

      temp._amount += quantityB.Amount;

      return temp;
    }


    static public Quantity operator -(Quantity quantityA, Quantity quantityB) {
      Quantity temp = new Quantity(quantityA);

      temp._amount -= quantityB.Amount;

      return temp;
    }


    static public Quantity operator *(Quantity quantity, decimal scalar) {
      Quantity temp = new Quantity(quantity);

      temp._amount *= scalar;

      return temp;
    }


    static public Quantity operator *(decimal scalar, Quantity quantity) {
      Quantity temp = new Quantity(quantity);

      temp._amount *= scalar;

      return temp;
    }


    static public Quantity operator /(Quantity quantity, decimal scalar) {
      Quantity temp = new Quantity(quantity);

      temp._amount /= scalar;

      return temp;
    }


    static public bool operator ==(Quantity quantityA, Quantity quantityB) {
      return quantityA.Unit.Equals(quantityB.Unit) && quantityA.Amount == quantityB.Amount;
    }


    static public bool operator !=(Quantity quantityA, Quantity quantityB) {
      return !(quantityA == quantityB);
    }

    #endregion Operators overloading

    #region Methods

    public override bool Equals(object o) {
      if (!(o is Quantity)) {
        return false;
      }
      Quantity temp = (Quantity) o;

      return Unit.Equals(temp.Unit) && Amount == temp.Amount;
    }


    public override int GetHashCode() {
      return _unit.GetHashCode() ^ _amount.GetHashCode();
    }


    public override string ToString() {
      if (Unit.Format == "Hectareas") {
        return FormatToHectareasString();
      }
      return EmpiriaString.TrimAll(_amount.ToString("#,##0.00######") + " " + _unit.Abbr);
    }

    #endregion Methods

    #region Helpers

    private string FormatToHectareasString() {
      var ha = Math.Truncate(_amount);
      var area = Math.Truncate((_amount - ha) * 100);
      var meters = (_amount - ha - area / 100) * 10000;

      if (meters == 0) {
        return $"{ha.ToString("00")}-{area.ToString("00")}-00 {_unit.Abbr}";
      } else if (Math.Truncate(meters) == meters) {
        return $"{ha.ToString("00")}-{area.ToString("00")}-{meters.ToString("00")} {_unit.Abbr}";
      } else {
        return $"{ha.ToString("00")}-{area.ToString("00")}-{meters.ToString("00.00######")} {_unit.Abbr}";
      }
    }

    #endregion Helpers

  } // struct Quantity

} // namespace Empiria.Measurement
