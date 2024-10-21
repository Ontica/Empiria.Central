/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Test cases                              *
*  Assembly : Empiria.Central.Core.Tests.dll             Pattern   : Unit tests                              *
*  Type     : SATCucopTests                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for SATCucop instances.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products.SATMexico;

namespace Empiria.Tests.Products.SATMexico {

  /// <summary>Unit tests for SATCucop instances.</summary>
  public class SATCucopTests {


    [Fact]
    public void Should_Read_All_SATCucop_Instances() {
      var sut = SATCucop.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }

    [Fact]
    public void Should_Read_Empty_SATCucop() {
      var sut = SATCucop.Empty;

      Assert.NotNull(sut);
    }

  }  // class SATCucopTests

}  // namespace Empiria.Tests.Products.SATMexico
