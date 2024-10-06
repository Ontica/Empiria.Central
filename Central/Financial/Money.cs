/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Value Type                              *
*  Type     : Money                                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Value type that represents a currency amount.                                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Json;

namespace Empiria.Financial {

  /// <summary>Value type that represents a currency amount.</summary>
  public struct Money {

    #region Fields

    private Currency _currency;

    private decimal _amount;

    #endregion Fields

    #region Constructors and parsers

    private Money(Money money) {
      _currency = money.Currency;
      _amount = money.Amount;
    }

    private Money(Currency currency, decimal amount) {
      _currency = currency;
      _amount = amount;
    }

    static public Money Parse(decimal amount) {
      return new Money(Currency.Default, amount);
    }

    static public Money Parse(Currency currency, decimal amount) {
      return new Money(currency, amount);
    }

    static public Money Parse(JsonObject json) {
      return Money.Parse(json.Get("CurrencyId", Currency.Default),
                         json.Get("Value", 0m));
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
      get { return _amount; }
    }


    public Currency Currency {
      get {
        if (_currency == null) {
          _currency = Currency.Default;
        }
        return _currency;
      }
    }

    #endregion Properties

    #region Operators overloading

    static public Money operator +(Money moneyA, Money moneyB) {
      Money temp = new Money(moneyA);

      temp._amount += moneyB.Amount;

      return temp;
    }


    static public Money operator -(Money moneyA, Money moneyB) {
      Money temp = new Money(moneyA);

      temp._amount -= moneyB.Amount;

      return temp;
    }


    static public Money operator *(Money money, decimal scalar) {
      Money temp = new Money(money);

      temp._amount *= scalar;

      return temp;
    }


    static public Money operator *(decimal scalar, Money money) {
      Money temp = new Money(money);

      temp._amount *= scalar;

      return temp;
    }


    static public Money operator /(Money moneyA, decimal scalar) {
      Money temp = new Money(moneyA);

      temp._amount /= scalar;

      return temp;
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
      return (_currency.GetHashCode() ^ _amount.GetHashCode());
    }


    public override string ToString() {

      if (this._currency.Equals(Currency.Default)) {
        return _amount.ToString("C2");

      } else if (this._currency.Equals(Currency.Empty)) {
        return _amount.ToString();

      } else {
        return _amount.ToString("0,###.00##" + " " + _currency.Abbreviation);

      }
    }

    #endregion Methods

  } // struct Money

} // namespace Empiria.Financial
