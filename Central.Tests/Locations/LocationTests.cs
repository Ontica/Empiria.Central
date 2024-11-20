/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Locations                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : LocationTests                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Location type.                                                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Locations;

namespace Empiria.Tests.Locations {

  /// <summary>Unit tests for Location type.</summary>
  public class LocationTests {

    #region Facts

    [Fact]
    public void Should_Get_All_Locations() {
      var sut = Location.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Parse_All_Locations() {
      var list = Location.GetList();

      foreach (var sut in list) {
        Assert.NotNull(sut.LocationType);
        Assert.NotNull(sut.Parent);
        Assert.NotNull(sut.GetChildren());
        Assert.NotNull(sut.FullName);
        Assert.True(sut.Level >= 1);
      }
    }


    [Fact]
    public void Should_Parse_Empty_Location() {
      var sut = Location.Empty;

      Assert.NotNull(sut);
      Assert.Empty(sut.GetChildren());
      Assert.Equal(sut, sut.Parent);
      Assert.Equal(0, sut.Level);
    }

    #endregion Facts

  }  // class LocationTests

}  // namespace Empiria.Tests.Locations
