/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Value Type                              *
*  Type     : Money                                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Value type that represents a currency amount.                                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Value type that represents a currency amount.</summary>
  public struct Money {

    #region Constructors and parsers

    public Money(decimal amount) {
      Currency = Currency.Default;
      Amount = amount;
    }

    public Money(Currency currency, decimal amount) {
      Currency = currency;
      Amount = amount;
    }

    static public Money Parse(decimal amount) {
      return new Money(Currency.Default, amount);
    }

    static public Money Parse(Currency currency, decimal amount) {
      return new Money(currency, amount);
    }

    static public Money Empty {
      get { return new Money(Currency.Empty, 0m); }
    }

    static public Money Zero {
      get { return new Money(Currency.Default, 0m); }
    }

    #endregion Constructors and parsers

    #region Properties

    public decimal Amount {
      get;
    }

    public Currency Currency {
      get;
    }

    #endregion Properties

    #region Operators overloading

    static public Money operator +(Money moneyA, Money moneyB) {
      Assertion.Require(moneyA.Currency.Equals(moneyB.Currency),
                        $"No se puede hacer la suma de monedas distintas: " +
                        $"{moneyA.Currency.Name} {moneyB.Currency.Name}.");

      return new Money(moneyA.Currency, moneyA.Amount + moneyB.Amount);
    }


    static public Money operator -(Money moneyA, Money moneyB) {
      Assertion.Require(moneyA.Currency.Equals(moneyB.Currency),
                        $"No se puede hacer la resta de monedas distintas: " +
                        $"{moneyA.Currency.Name} {moneyB.Currency.Name}.");

      return new Money(moneyA.Currency, moneyA.Amount - moneyB.Amount);
    }


    static public Money operator *(Money money, decimal scalar) {
      return new Money(money.Currency, money.Amount * scalar);
    }


    static public Money operator *(decimal scalar, Money money) {
      return new Money(money.Currency, money.Amount * scalar);
    }


    static public Money operator /(Money money, decimal scalar) {
      Assertion.Require(scalar != 0, "No se puede una cantidad monetaria entre cero.");

      return new Money(money.Currency, money.Amount / scalar);
    }


    static public bool operator ==(Money moneyA, Money moneyB) {
      return (moneyA.Currency.Equals(moneyB.Currency) && (moneyA.Amount == moneyB.Amount));
    }


    static public bool operator !=(Money moneyA, Money moneyB) {
      return !(moneyA == moneyB);
    }

    #endregion Operators overloading

    #region Methods

    public override bool Equals(object o) {
      if (!(o is Money)) {
        return false;
      }
      Money temp = (Money) o;

      return (this.Currency.Equals(temp.Currency) && (this.Amount == temp.Amount));
    }


    public override int GetHashCode() {
      return (Currency, Amount).GetHashCode();
    }


    public override string ToString() {

      if (Currency.Equals(Currency.Default)) {
        return Amount.ToString("C2");

      } else if (Currency.Equals(Currency.Empty)) {
        return Amount.ToString();

      } else {
        return Amount.ToString("0,###.00##" + " " + Currency.ISOCode);

      }
    }

    #endregion Methods

  } // struct Money

} // namespace Empiria.Financial
