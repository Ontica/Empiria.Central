/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : Accountability                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents an accountability or reponsibility between a party and a person.                    *
*                                                                                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Parties;

namespace Empiria.HumanResources {

  /// <summary>Represents an accountability or reponsibility between a party and a person.</summary>
  public class Accountability : PartyRelation {

    #region Constructors and parsers

    protected Accountability(PartyRelationType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    internal Accountability(PartyRole role, Party commissioner, Party responsible) :
                                                  base(role, commissioner, responsible) {
      // no-op
    }

    static public new Accountability Parse(int id) => ParseId<Accountability>(id);

    static public new Accountability Parse(string uid) => ParseKey<Accountability>(uid);

    static public new Accountability Empty => ParseEmpty<Accountability>();

    static public FixedList<Accountability> GetList() {
      var accountabilities = GetList<Accountability>("PTY_REL_STATUS <> 'X'");

      return accountabilities.ToFixedList();
    }


    static public FixedList<T> GetCommissionersFor<T>(Party responsible,
                                                      string listName, string role) where T : Party {

      Assertion.Require(responsible, nameof(responsible));
      Assertion.Require(listName, nameof(listName));
      Assertion.Require(role, nameof(role));

      FixedList<T> commissioners = Party.GetList<T>(DateTime.Today)
                                        .FindAll(x => x.PlaysRole(listName));

      commissioners.Sort((x, y) => ((INamedEntity) x).Name.CompareTo(((INamedEntity) y).Name));

      FixedList<PartyRole> securityRoles = responsible.GetSecurityRoles();

      if (securityRoles.Contains(x => x.HasOrganizationalScope)) {
        return commissioners;
      }

      FixedList<Accountability> accountabilities = GetListForResponsible(responsible);

      return commissioners.FindAll(x => accountabilities.Contains(y => y.Commissioner.Equals(x)));
    }


    static public FixedList<Accountability> GetListForCommissioner(Party commissioner) {
      Assertion.Require(commissioner, nameof(commissioner));
      Assertion.Require(!commissioner.IsEmptyInstance, nameof(commissioner));

      var accountabilities = GetList<Accountability>($"PTY_REL_COMMISSIONER_ID = {commissioner.Id} AND " +
                                                     $"PTY_REL_STATUS <> 'X'");

      return accountabilities.ToFixedList()
                             .Sort((x, y) => $"{x.Role.Name}|{x.Responsible.Name}".CompareTo(
                                             $"{y.Role.Name}|{y.Responsible.Name}")
                             );
    }


    static public FixedList<Accountability> GetListForResponsible(Party responsible) {
      Assertion.Require(responsible, nameof(responsible));
      Assertion.Require(!responsible.IsEmptyInstance, nameof(responsible));

      var accountabilities = GetList<Accountability>($"PTY_REL_RESPONSIBLE_ID = {responsible.Id} AND " +
                                                     $"PTY_REL_STATUS <> 'X'");

      return accountabilities.ToFixedList()
                             .Sort((x, y) => $"{x.Role.Name}|{x.Commissioner.Name}".CompareTo(
                                             $"{y.Role.Name}|{y.Commissioner.Name}")
                             );
    }


    static public FixedList<string> GetResponsibleRoles(Party responsible) {
      FixedList<PartyRole> securityRoles = responsible.GetSecurityRoles();

      return GetListForResponsible(responsible)
            .SelectDistinctFlat(x => x.Role.AppliesTo);
    }

    #endregion Constructors and parsers

    #region Properties

    public new string Code {
      get {
        return base.Code;
      }
    }


    public new Party Commissioner {
      get {
        return base.Commissioner;
      }
    }


    public new Person Responsible {
      get {
        return (Person) base.Responsible;
      }
    }


    public new PartyRole Role {
      get {
        return base.Role;
      }
    }

    #endregion Properties

    #region Methods

    internal new void Update(PartyRelationFields fields) {
      Assertion.Require(fields, nameof(fields));

      base.Update(fields);
    }

    internal new void Delete() {
      base.Delete();
    }

    #endregion Methods

  } // class Accountability

} // namespace Empiria.HumanResources
