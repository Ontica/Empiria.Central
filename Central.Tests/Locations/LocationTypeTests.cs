/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Locations                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : LocationTypeTests                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for LocationType.                                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Locations;

namespace Empiria.Tests.Locations {

  /// <summary>Unit tests for LocationType.</summary>
  public class LocationTypeTests {

    #region Facts

    [Fact]
    public void Should_Get_All_Location_Types() {
      var sut = LocationType.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Parse_Empty_LocationType() {
      var sut = LocationType.Empty;

      Assert.NotNull(sut);
    }

    #endregion Facts

  }  // class LocationTypeTests

}  // namespace Empiria.Tests.Locations
