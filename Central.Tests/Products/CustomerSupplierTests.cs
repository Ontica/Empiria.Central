/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : CustomerSupplierTests                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for CustomerSupplier instances.                                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Products;
using Empiria.Parties;

namespace Empiria.Tests.Products {

  /// <summary>Unit tests for CustomerSupplier instances.</summary>
  public class CustomerSupplierTests {

    [Fact]
    public void Should_Get_Empty_Supplier() {
      var sut = CustomerSupplier.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
    }


    [Fact]
    public void Should_Get_All_Suppliers() {
      var sut = BaseObject.GetList<CustomerSupplier>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Parse_All_Suppliers() {
      var customerSuppliers = BaseObject.GetList<CustomerSupplier>();

      foreach (var sut in customerSuppliers) {
        Assert.NotEqual(Party.Empty, sut.Customer);
        Assert.NotEqual(Party.Empty, sut.Supplier);
      }
    }

  }  // class CustomerSupplierTests

}  // namespace Empiria.Tests.Products
