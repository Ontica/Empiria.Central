/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Mapper                                  *
*  Type     : PaymentAccountMapper                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Maps PaymentAccount instances to their DTOs.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial.Adapters {

  /// <summary>Maps PaymentAccount instances to their DTOs.</summary>
  static public class PaymentAccountMapper {

    static public FixedList<PaymentAccountDto> Map(FixedList<PaymentAccount> accounts) {
      return accounts.Select(x => Map(x))
                     .ToFixedList();
    }

    static public PaymentAccountDto Map(PaymentAccount account) {
      return new PaymentAccountDto {
        UID = account.UID,
        Name = account.Identificator,
        PaymentMethod = PaymentMethodMapper.Map(account.PaymentMethod),
        Currency = account.Currency.MapToNamedEntity(),
        Institution = account.Institution.MapToNamedEntity(),
        AccountNo = account.AccountNo,
        HolderName = account.HolderName,
        CLABE = account.CLABE
      };
    }

  }  // class PaymentAccountMapper

}  // namespace Empiria.Financial.Adapters
