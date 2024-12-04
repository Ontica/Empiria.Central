/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.Core.dll                   Pattern   : Integration interface                   *
*  Type     : IPayable                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Defines a payable.                                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Defines a payable.</summary>
  public interface IPayable {

    int Id {
      get;
    }

    IPayableEntity PayableEntity {
      get;
    }

  }  // interface IPayable

}  // namespace Empiria.Financial
