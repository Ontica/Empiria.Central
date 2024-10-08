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

    #region Constructors and parsers

    public Quantity(Unit unit, decimal amount) {
      Unit = unit;
      Amount = amount;
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
      get;
    }


    public Unit Unit {
      get;
    }

    #endregion Properties

    #region Operators overloading

    static public Quantity operator +(Quantity quantityA, Quantity quantityB) {
      Assertion.Require(quantityA.Unit.Equals(quantityB.Unit),
                  $"No se puede hacer la suma entre unidades distintas: " +
                  $"{quantityA.Unit.Name} {quantityB.Unit.Name}.");

      return new Quantity(quantityA.Unit, quantityA.Amount + quantityB.Amount);
    }


    static public Quantity operator -(Quantity quantityA, Quantity quantityB) {
      Assertion.Require(quantityA.Unit.Equals(quantityB.Unit),
                  $"No se puede hacer la resta entre unidades distintas: " +
                  $"{quantityA.Unit.Name} {quantityB.Unit.Name}.");

      return new Quantity(quantityA.Unit, quantityA.Amount - quantityB.Amount);
    }


    static public Quantity operator *(Quantity quantity, decimal scalar) {
      return new Quantity(quantity.Unit, quantity.Amount * scalar);
    }


    static public Quantity operator *(decimal scalar, Quantity quantity) {
      return new Quantity(quantity.Unit, quantity.Amount * scalar);
    }


    static public Quantity operator /(Quantity quantity, decimal scalar) {
      Assertion.Require(scalar != 0, "No se puede dividr una cantidad entre cero.");

      return new Quantity(quantity.Unit, quantity.Amount / scalar);
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
      return (Unit, Amount).GetHashCode();
    }


    public override string ToString() {
      if (Unit.Format == "Hectareas") {
        return FormatToHectareasString();
      }
      return EmpiriaString.TrimAll(Amount.ToString("#,##0.00######") + " " + Unit.Abbr);
    }

    #endregion Methods

    #region Helpers

    private string FormatToHectareasString() {
      var ha = Math.Truncate(Amount);
      var area = Math.Truncate((Amount - ha) * 100);
      var meters = (Amount - ha - area / 100) * 10000;

      if (meters == 0) {
        return $"{ha.ToString("00")}-{area.ToString("00")}-00 {Unit.Abbr}";
      } else if (Math.Truncate(meters) == meters) {
        return $"{ha.ToString("00")}-{area.ToString("00")}-{meters.ToString("00")} {Unit.Abbr}";
      } else {
        return $"{ha.ToString("00")}-{area.ToString("00")}-{meters.ToString("00.00######")} {Unit.Abbr}";
      }
    }

    #endregion Helpers

  } // struct Quantity

} // namespace Empiria.Measurement
