/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Partitioned type                        *
*  Type     : Product                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Partitioned type that represents a good or a service.                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Json;
using Empiria.Ontology;
using Empiria.Parties;
using Empiria.StateEnums;

namespace Empiria.Products {

  /// <summary>Partitioned type that represents a good or a service.</summary>
  [PartitionedType(typeof(ProductType))]
  public class Product : BaseObject, INamedEntity {

    #region Constructors and parsers

    protected Product(ProductType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    internal protected Product(ProductType powertype, string name) : base(powertype) {
      name = EmpiriaString.Clean(name);

      Assertion.Require(name, nameof(name));

      this.Name = name;
    }

    static public Product Parse(int id) => ParseId<Product>(id);

    static public Product Parse(string uid) => ParseKey<Product>(uid);

    static public Product Empty => ParseEmpty<Product>();

    #endregion Constructors and parsers

    #region Properties

    public ProductType ProductType {
      get {
        return (ProductType) base.GetEmpiriaType();
      }
    }


    [DataField("PRODUCT_NAME")]
    public string Name {
      get;
      private set;
    }


    [DataField("PRODUCT_DESCRIPTION")]
    public string Description {
      get;
      private set;
    }


    [DataField("PRODUCT_INTERNAL_CODE")]
    public string InternalCode {
      get;
      private set;
    }


    [DataField("PRODUCT_TAGS")]
    private string _tags = string.Empty;

    public FixedList<string> Tags {
      get {
        return _tags.Split(' ').ToFixedList();
      }
    }


    [DataField("PRODUCT_ATTRIBUTES")]
    public JsonObject Attributes {
      get;
      private set;
    }


    [DataField("PRODUCT_BILLING_DATA")]
    public JsonObject BillingData {
      get;
      private set;
    }


    [DataField("PRODUCT_BUDGETING_DATA")]
    public JsonObject BudgetingData {
      get;
      private set;
    }


    [DataField("PRODUCT_BASE_UNIT_ID")]
    public ProductUnit BaseUnit {
      get;
      private set;
    }


    [DataField("PRODUCT_MANAGER_ID")]
    public Party Manager {
      get;
      private set;
    }


    [DataField("PRODUCT_EXT_DATA")]
    protected internal JsonObject ExtensionData {
      get;
      private set;
    }


    [DataField("PRODUCT_START_DATE")]
    public DateTime StartDate {
      get;
      private set;
    }


    [DataField("PRODUCT_END_DATE")]
    public DateTime EndDate {
      get;
      private set;
    }


    [DataField("PRODUCT_STATUS", Default = EntityStatus.Active)]
    public EntityStatus Status {
      get;
      private set;
    }


    protected internal virtual string Keywords {
      get {
        return EmpiriaString.BuildKeywords(InternalCode, Name,
                                           ProductType.DisplayName, Description);
      }
    }

    #endregion Properties

    #region Methods

    protected override void OnSave() {
      throw new System.NotImplementedException();
    }

    #endregion Methods

  } // class Product

}  // namespace Empiria.Products
