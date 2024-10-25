/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : SupplierRelation                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a supplier relation. A supplier relation is not a supplier.                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.Products {

  /// <summary>Represents a supplier relation. A supplier relation is not a supplier.</summary>
  public class SupplierRelation : PartyRelation {

    #region Constructors and parsers

    protected SupplierRelation(PartyRelationType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    static public new SupplierRelation Parse(int id) => ParseId<SupplierRelation>(id);

    static public new SupplierRelation Parse(string uid) => ParseKey<SupplierRelation>(uid);

    static public new SupplierRelation Empty => ParseEmpty<SupplierRelation>();

    #endregion Constructors and parsers

    #region Properties

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


    public Party Supplier {
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
