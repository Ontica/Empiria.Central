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

    static internal FixedList<Accountability> GetListFor(Party commissioner) {
      Assertion.Require(commissioner, nameof(commissioner));
      Assertion.Require(!commissioner.IsEmptyInstance, nameof(commissioner));

      var accountabilities = GetList<Accountability>($"PTY_REL_COMMISSIONER_ID = {commissioner.Id} AND " +
                                                     $"PTY_REL_STATUS <> 'X'");

      return accountabilities.ToFixedList()
                             .Sort((x, y) => $"{x.Responsible.Name}|{x.Role.Name}".CompareTo(
                                             $"{y.Responsible.Name}|{y.Role.Name}")
                             );
    }


    #endregion Constructors and parsers

    #region Properties

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
