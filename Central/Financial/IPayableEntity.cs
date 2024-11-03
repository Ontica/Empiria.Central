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

using System.Collections.Generic;

namespace Empiria.Financial {

  /// <summary>Defines a payable entity. Payable entities are purchase orders,
  /// contract milestones, invoices, paychecks, etc.
  /// </summary>
  public interface IPayableEntity {

    int Id {
      get;
    }

    string UID {
      get;
    }

    INamedEntity Type {
      get;
    }

    string EntityNo {
      get;
    }

    string Name {
      get;
    }

    string Description {
      get;
    }

    INamedEntity PayTo {
      get;
    }

    IEnumerable<IPayableEntityItem> Items {
      get;
    }

  }  // interface IPayableEntity


  public interface IPayableEntityItem {

    int Id {
      get;
    }


    string UID {
      get;
    }


    decimal Quantity {
      get;
    }


    INamedEntity Unit {
      get;
    }


    decimal UnitPrice {
      get;
    }

    INamedEntity Currency {
      get;
    }


    INamedEntity Product {
      get;
    }


    string Description {
      get;
    }


    INamedEntity BudgetAccount {
      get;
    }


    decimal Total {
      get;
    }

  }  // interface IPayableEntityItem

}  // namespace Empiria.Financial
