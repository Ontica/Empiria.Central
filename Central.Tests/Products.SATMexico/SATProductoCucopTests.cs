/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Test cases                              *
*  Assembly : Empiria.Central.Core.Tests.dll             Pattern   : Unit tests                              *
*  Type     : SATProductoCucopTests                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for SATProductoCucop instances.                                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products.SATMexico;

namespace Empiria.Tests.Products.SATMexico {

  /// <summary>Unit tests for SATProductoCucop instances.</summary>
  public class SATProductoCucopTests {


    [Fact]
    public void Should_Read_All_SATProductoCucop_Instances() {
      var sut = SATProductoCucop.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Read_Empty_SATProductoCucop() {
      var sut = SATProductoCucop.Empty;

      Assert.NotNull(sut);
    }

  }  // class SATProductoCucopTests

}  // namespace Empiria.Tests.Products.SATMexico
