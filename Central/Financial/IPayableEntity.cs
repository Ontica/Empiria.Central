/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.Core.dll                   Pattern   : Integration interface                   *
*  Type     : IPayableEntity                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Defines a payable entity. Payable entities are purchase orders,                                *
*             contract milestones, invoices, paychecks, etc.                                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Defines a payable entity. Payable entities are purchase orders,
  /// contract milestones, invoices, paychecks, etc.
  /// </summary>
  public interface IPayableEntity {

    int Id {
      get;
    }

    string EntityNo {
      get;
    }

  }  // interface IPayableEntity

}  // namespace Empiria.Financial
