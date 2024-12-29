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

    public PaymentMethodDto PaymentMethod {
      get; internal set;
    }

    public NamedEntityDto Currency {
      get; internal set;
    }

    public NamedEntityDto Institution {
      get; internal set;
    }

    public string AccountNo {
      get; internal set;
    }

    public string HolderName {
      get; internal set;
    }

    public string CLABE {
      get; internal set;
    }

  }  // class PaymentAccountDto

}  // namespace Empiria.Financial.Adapters
