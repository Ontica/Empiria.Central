/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : PaymentMethodTests                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for PaymentMethod instances.                                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Financial;

namespace Empiria.Tests.Financial {

  /// <summary>Unit tests for PaymentMethod instances.</summary>
  public class PaymentMethodTests {

    #region Facts

    [Fact]
    public void Should_Get_All_PaymentMethods() {
      var sut = PaymentMethod.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Parse_Empty_PaymentMethod() {
      var sut = PaymentMethod.Empty;

      Assert.NotNull(sut);
    }

    #endregion Facts

  }  // class PaymentMethodTests

}  // namespace Empiria.Tests.Financial
