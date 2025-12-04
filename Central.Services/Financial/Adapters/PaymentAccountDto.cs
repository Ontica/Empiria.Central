/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Output DTO                              *
*  Type     : PaymentAccountDto                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for PaymentAccount instances.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial.Adapters {

  /// <summary>Output DTO for PaymentAccount instances.</summary>
  public class PaymentAccountDto : NamedEntityFields {

    public PaymentAccountDto(PaymentAccount account) {
      PaymentMethod = new PaymentMethodDto(account.PaymentMethod);
      Currency = new NamedEntityDto(account.Currency);
      Institution = new NamedEntityDto(account.Institution);
      AccountNo = account.AccountNo;
      HolderName = account.HolderName;
      CLABE = account.CLABE;
    }

    #region Properties

    public PaymentMethodDto PaymentMethod {
      get;
    }

    public NamedEntityDto Currency {
      get;
    }

    public NamedEntityDto Institution {
      get;
    }

    public string AccountNo {
      get;
    }

    public string HolderName {
      get;
    }

    public string CLABE {
      get;
    }

    #endregion Properties

    #region Mappers

    static public FixedList<PaymentAccountDto> Map(FixedList<PaymentAccount> accounts) {
      return accounts.Select(x => new PaymentAccountDto(x))
                     .ToFixedList();
    }

    #endregion Mappers

  }  // class PaymentAccountDto

}  // namespace Empiria.Financial.Adapters
