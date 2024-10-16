/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Parties                                    Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : Supplier                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a supplier.                                                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Parties {

  /// <summary>Represents a supplier.</summary>
  public class Supplier : PartyRelation, INamedEntity {

    #region Constructors and parsers

    protected Supplier(PartyRelationType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    static public new Supplier Parse(int id) => ParseId<Supplier>(id);

    static public new Supplier Parse(string uid) => ParseKey<Supplier>(uid);

    static public FixedList<Supplier> GetListFor(Party customer) {
      return GetFullList<Supplier>($"COMMISSIONER_PARTY_ID = {customer.Id}")
            .Sort((x, y) => x.Name.CompareTo(y.Name));
    }

    static public new Supplier Empty => ParseEmpty<Supplier>();

    #endregion Constructors and parsers

    #region Properties


    public string Name {
      get {
        return base.Responsible.Name;
      }
    }


    public string SupplierNo {
      get {
        return ExtendedData.Get("supplierNo", string.Empty);
      }
      private set {
        ExtendedData.SetIfValue("supplierNo", value);
      }
    }


    public string SubledgerAccount {
      get {
        return ExtendedData.Get("subledgerAccount", string.Empty);
      }
      private set {
        ExtendedData.SetIfValue("subledgerAccount", value);
      }
    }


    public Party Customer {
      get {
        return base.Commissioner;
      }
    }


    public Party This {
      get {
        return base.Responsible;
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(base.Keywords, SupplierNo, SubledgerAccount);
      }
    }

    #endregion Properties

  } // class Supplier

} // namespace Empiria.Parties
