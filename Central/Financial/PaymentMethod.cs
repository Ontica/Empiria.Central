/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.Core.dll                   Pattern   : Common Storage type                     *
*  Type     : PaymentMethod                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a payment method.                                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Represents a payment method.</summary>
  public class PaymentMethod : CommonStorage {

    #region Constructors and parsers

    static public PaymentMethod Parse(int id) => ParseId<PaymentMethod>(id);

    static public PaymentMethod Parse(string uid) => ParseKey<PaymentMethod>(uid);

    static public FixedList<PaymentMethod> GetList() {
      return GetList<PaymentMethod>()
            .ToFixedList();
    }

    static public PaymentMethod Empty => ParseEmpty<PaymentMethod>();

    #endregion Constructors and parsers

    #region Properties

    public bool LinkedToAccount {
      get {
        return base.ExtData.Get("linkedToAccount", false);
      }
    }

    #endregion Properties

  }  // class PaymentMethod

}  // namespace Empiria.Financial
