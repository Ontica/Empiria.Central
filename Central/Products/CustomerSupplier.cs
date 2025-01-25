/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : CustomerSupplier                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a customer-supplier relationship between two parties.                               *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.Products {

  /// <summary>Represents a customer-supplier relationship between two parties.</summary>
  public class CustomerSupplier : PartyRelation {

    #region Constructors and parsers

    protected CustomerSupplier(PartyRelationType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    static public new CustomerSupplier Parse(int id) => ParseId<CustomerSupplier>(id);

    static public new CustomerSupplier Parse(string uid) => ParseKey<CustomerSupplier>(uid);

    static public new CustomerSupplier Empty => ParseEmpty<CustomerSupplier>();

    #endregion Constructors and parsers

    #region Properties

    public string CustomerNo {
      get {
        return ExtendedData.Get("customerNo", string.Empty);
      }
      private set {
        ExtendedData.SetIfValue("customerNo", value);
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
        return EmpiriaString.BuildKeywords(base.Keywords, CustomerNo, SupplierNo,
                                           Customer.Keywords, Supplier.Keywords);
      }
    }

    #endregion Properties

  } // class CustomerSupplier

} // namespace Empiria.Products
