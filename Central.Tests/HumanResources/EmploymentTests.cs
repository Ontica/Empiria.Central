/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : EmploymentTests                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Employment instances.                                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Parties;

using Empiria.HumanResources;

namespace Empiria.Tests.HumanResources {

  /// <summary>Unit tests for Employment instances.</summary>
  public class EmploymentTests {

    [Fact]
    public void Should_Get_Empty_Employment() {
      var sut = Employment.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.Equal(Employment.Parse("Empty"), sut);
      Assert.Equal("N/D", sut.EmployeeNo);
    }


    [Fact]
    public void Should_Get_All_Employments() {
      var sut = BaseObject.GetList<Employment>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Parse_All_Employments() {
      var employments = BaseObject.GetList<Employment>();

      foreach (var sut in employments) {
        Assert.NotEqual(Party.Empty, sut.Employer);
        Assert.NotEqual(Party.Empty, sut.Employee);
        Assert.True(typeof(Organization).Equals(sut.Employer.GetType()) ||
                    typeof(Person).Equals(sut.Employer.GetType()));
        Assert.NotEmpty(sut.EmployeeNo);
      }
    }

  }  // class EmploymentTests

}  // namespace Empiria.Tests.HumanResources
