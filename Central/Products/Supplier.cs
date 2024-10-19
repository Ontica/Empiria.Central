/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : Supplier                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a supplier. A supplier is a relation between two parties.                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.Products {

  /// <summary>Represents a supplier. A supplier is a relation between two parties.</summary>
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
        return Responsible.Name;
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
        return Commissioner;
      }
    }


    public Party AsParty {
      get {
        return Responsible;
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(base.Keywords, SupplierNo, SubledgerAccount);
      }
    }

    #endregion Properties

  } // class Supplier

} // namespace Empiria.Products
