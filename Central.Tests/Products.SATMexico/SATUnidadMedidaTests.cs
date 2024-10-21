/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Test cases                              *
*  Assembly : Empiria.Central.Core.Tests.dll             Pattern   : Unit tests                              *
*  Type     : SATUnidadMedidaTests                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for SATUnidadMedida instances.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products.SATMexico;

namespace Empiria.Tests.Products.SATMexico {

  /// <summary>Unit tests for SATUnidadMedida instances.</summary>
  public class SATUnidadMedidaTests {

    [Fact]
    public void Should_Read_All_SATUnidadMedida_Instances() {
      var sut = SATUnidadMedida.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Read_Empty_SATUnidadMedida() {
      var sut = SATUnidadMedida.Empty;

      Assert.NotNull(sut);
    }

  }  // class SATUnidadMedidaTests

}  // namespace Empiria.Tests.Products.SATMexico
