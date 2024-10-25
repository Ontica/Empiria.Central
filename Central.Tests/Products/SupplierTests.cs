/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : SupplierTests                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Supplier instances.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;
using Empiria.Parties;

namespace Empiria.Tests.Products {

  /// <summary>Unit tests for Supplier instances.</summary>
  public class SupplierTests {

    [Fact]
    public void Should_Get_Empty_Supplier() {
      var sut = SupplierRelation.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
    }


    [Fact]
    public void Should_Get_All_Suppliers() {
      var sut = BaseObject.GetList<SupplierRelation>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Parse_All_Suppliers() {
      var suppliers = BaseObject.GetList<SupplierRelation>();

      foreach (var sut in suppliers) {
        Assert.NotEqual(Party.Empty, sut.Commissioner);
        Assert.NotEqual(Party.Empty, sut.Supplier);
      }
    }

  }  // class SupplierTests

}  // namespace Empiria.Tests.Products
