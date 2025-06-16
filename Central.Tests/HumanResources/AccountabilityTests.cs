/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : AccountabilityTests                        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Accountability instances.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Ontology;
using Empiria.Parties;

using Empiria.HumanResources;

namespace Empiria.Tests.HumanResources {

  /// <summary>Unit tests for Accountability instances.</summary>
  public class AccountabilityTests {

    [Fact]
    public void Should_Create_Accountability() {
      var role = TestsObjects.TryGetObject<PartyRole>();
      var commissioner = TestsObjects.TryGetObject<OrganizationalUnit>();
      var responsible = TestsObjects.TryGetObject<Person>();

      var sut = new Accountability(role, commissioner, responsible);

      Assert.Equal(ObjectTypeInfo.Parse<Accountability>(), sut.PartyRelationType);
      Assert.Equal(role, sut.Role);
      Assert.Equal(commissioner, sut.Commissioner);
      Assert.Equal(responsible, sut.Responsible);
      Assert.Equal(StateEnums.EntityStatus.Active, sut.Status);
    }


    [Fact]
    public void Should_Get_Empty_Accountability() {
      var sut = Accountability.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.Equal(Accountability.Parse("Empty"), sut);
    }


    [Fact]
    public void Should_Get_All_Accountabilities() {
      var sut = Accountability.GetList();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Parse_All_Accountabilities() {
      var accountabilities = Accountability.GetList();

      foreach (var sut in accountabilities) {
        Assert.NotNull(sut.Commissioner);
        Assert.NotNull(sut.Responsible);
        Assert.NotEqual(sut.Commissioner, sut.Responsible);
        Assert.NotNull(sut.Role);
        Assert.True(sut.StartDate <= sut.EndDate);
      }
    }

  }  // class AccountabilityTests

}  // namespace Empiria.Tests.HumanResources
