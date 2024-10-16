/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Parties                                    Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : SupplierTests                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Supplier instances.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Parties;

namespace Empiria.Tests.Parties {

  /// <summary>Unit tests for Supplier instances.</summary>
  public class SupplierTests {

    [Fact]
    public void Should_Get_Empty_Supplier() {
      var sut = Supplier.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
    }


    [Fact]
    public void Should_Get_All_Suppliers() {
      var sut = Supplier.GetList<Supplier>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }

  }  // class SupplierTests

}  // namespace Empiria.Tests
