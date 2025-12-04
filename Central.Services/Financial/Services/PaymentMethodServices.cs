/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : ProjectServices                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for PaymentMethod instances.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Financial.Adapters;

namespace Empiria.Financial.Services {

  /// <summary>Services for project instances.</summary>
  public class PaymentMethodServices : Service {

    #region Constructors and parsers

    protected PaymentMethodServices() {
      // no-op
    }

    static public PaymentMethodServices ServiceInteractor() {
      return Service.CreateInstance<PaymentMethodServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public FixedList<PaymentMethodDto> GetPaymentMethods() {

      var list = PaymentMethod.GetList();

      return PaymentMethodDto.Map(list);
    }

    #endregion Services

  }  // class PaymentMethodServices

}  // namespace Empiria.Financial.Services
