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
  public class PaymentAccountDto : NamedEntityDto {

    public PaymentAccountDto(PaymentAccount account) : base(account) {
      if (account.IsEmptyInstance) {
        PaymentMethod = new PaymentMethodDto(Financial.PaymentMethod.Parse(1595));
      } else {
        PaymentMethod = new PaymentMethodDto(account.PaymentMethod);
      }
      AccountType = account.GetEmpiriaType().MapToNamedEntity();
      Institution = account.Institution.MapToNamedEntity();
      AccountNo = account.AccountNo;
      Currency = account.Currency.MapToNamedEntity();

      HolderName = account.HolderName;
      ReferenceNumber = account.ReferenceNumber;
      AskForReferenceNumber = account.AskForReferenceNumber;
    }

    #region Properties

    public NamedEntityDto AccountType {
      get;
    }

    public PaymentMethodDto PaymentMethod {
      get;
    }

    public NamedEntityDto Institution {
      get;
    }

    public string AccountNo {
      get;
    }

    public NamedEntityDto Currency {
      get;
    }

    public string HolderName {
      get;
    }

    public string ReferenceNumber {
      get;
    }

    public bool AskForReferenceNumber {
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
