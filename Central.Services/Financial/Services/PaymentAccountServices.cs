/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Static services provider                *
*  Type     : PaymentAccountServices                     License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Static services for PaymentAccount instances.                                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

using Empiria.Financial.Adapters;

namespace Empiria.Financial.Services {

  /// <summary>Static services for PaymentAccount instances.</summary>
  static public class PaymentAccountServices {

    #region Services

    static public FixedList<PaymentAccountDto> GetPaymentAccounts(string partyUID) {
      Assertion.Require(partyUID, nameof(partyUID));

      var party = Party.Parse(partyUID);

      var accounts = PaymentAccount.GetListFor(party);

      return PaymentAccountMapper.Map(accounts);
    }

    #endregion Services

  }  // class PaymentAccountServices

}  // namespace Empiria.Financial.Services
