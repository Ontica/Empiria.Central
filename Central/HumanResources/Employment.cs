/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : Employment                                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents an employment as a relationship between an organization (or person) and a person.   *
*             An employment relation has one or many position assignments.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.HumanResources {

  /// <summary>Represents an employment as a relationship between an organization (or person) and a person.
  /// An employment relation has one or many position assignments.</summary>
  public class Employment : PartyRelation {

    #region Constructors and parsers

    protected Employment(PartyRelationType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    static public new Employment Parse(int id) => ParseId<Employment>(id);

    static public new Employment Parse(string uid) => ParseKey<Employment>(uid);

    static public new Employment Empty => ParseEmpty<Employment>();

    static public FixedList<Person> GetEmployees() {
      var employments = GetList();

      return employments.Select(e => e.Employee).ToFixedList();
    }

    static public FixedList<Employment> GetList() {
      var employments = GetList<Employment>("PARTY_RELATION_STATUS <> 'X'");

      return employments.ToFixedList();
    }

    #endregion Constructors and parsers

    #region Properties

    public Party Employer {
      get {
        return Commissioner;
      }
    }


    public Person Employee {
      get {
        return (Person) Responsible;
      }
    }


    public string EmployeeNo {
      get {
        return base.ExtendedData.Get("employeeNo", "N/D");
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(base.Keywords, EmployeeNo, Employee.Keywords, Employer.Keywords);
      }
    }

    #endregion Properties

  } // class Employment

} // namespace Empiria.HumanResources
