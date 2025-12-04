/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Output DTO                              *
*  Type     : PaymentMethodDto                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for PaymentMethod instances.                                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial.Adapters {

  /// <summary>Output DTO for PaymentMethod instances.</summary>
  public class PaymentMethodDto : NamedEntityFields {

    public PaymentMethodDto(PaymentMethod x) {
      base.UID = x.UID;
      base.Name = x.Name;
      AccountRelated = x.AccountRelated;
    }

    public bool AccountRelated {
      get;
    }

    #region Mappers

    static public FixedList<PaymentMethodDto> Map(FixedList<PaymentMethod> methods) {
      return methods.Select(x => new PaymentMethodDto(x))
                    .ToFixedList();
    }

    #endregion Mappers

  }  // class PaymentMethodDto

}  // namespace Empiria.Financial.Adapters
