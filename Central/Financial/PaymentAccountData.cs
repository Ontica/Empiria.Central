/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Data Layer                              *
*  Assembly : Empiria.Central.dll                        Pattern   : Data Services                           *
*  Type     : PaymentAccountData                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data read and write services for payment accounts.                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;

namespace Empiria.Financial {

  /// <summary>Provides data read and write services for payment accounts.</summary>
  static internal class PaymentAccountData {

    static internal void Write(PaymentAccount o) {

      var op = DataOperation.Parse("write_FMS_Payment_Account",
        o.Id, o.UID, o.AccountType.Id, o.Party.Id, o.Currency.Id,
        o.PaymentMethod.Id, o.Institution.Id, o.AccountNo, o.ExtData.ToString(),
        o.Keywords, o.PostedBy.Id, o.PostingTime, (char) o.Status);

      DataWriter.Execute(op);
    }

  }  // class PaymentAccountData

} // namespace Empiria.Financial
