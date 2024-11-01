/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Adpaters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Mapper                                  *
*  Type     : PaymentMethodMapper                        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Maps PaymentMethod instances to their DTOs.                                                    *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial.Adapters {

  /// <summary>Maps PaymentMethod instances to their DTOs.</summary>
  static internal class PaymentMethodMapper {

    static internal FixedList<PaymentMethodDto> Map(FixedList<PaymentMethod> paymentMethods) {
      return paymentMethods.Select(x => Map(x))
                           .ToFixedList();
    }


    static internal PaymentMethodDto Map(PaymentMethod paymentMethod) {
      return new PaymentMethodDto {
        UID = paymentMethod.UID,
        Name = paymentMethod.Name,
        LinkedToAccount = paymentMethod.LinkedToAccount
      };
    }

  }  // class PaymentMethodMapper

}  // namespace Empiria.Financial.Adapters
