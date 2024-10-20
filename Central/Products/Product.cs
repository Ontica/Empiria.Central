﻿/* Empiria Central  ******************************************************************************************
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

    static readonly DateTime DEFAULT_START_DATE = new DateTime(2021, 1, 1);

    #region Constructors and parsers

    protected Product(ProductType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    internal protected Product(ProductKind productKind, string name) : base(productKind.ProductType) {
      ProductKind = productKind;
      name = EmpiriaString.Clean(name);

      Assertion.Require(name, nameof(name));

      Name = name;
      BaseUnit = ProductUnit.Empty;
      Manager = Party.Primary;
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


    [DataField("PRODUCT_KIND_ID")]
    public ProductKind ProductKind {
      get;
      private set;
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

    internal void Delete() {
      this.Status = EntityStatus.Deleted;
      this.EndDate = DateTime.Today;
    }


    protected override void OnSave() {
      if (this.IsNew) {
        StartDate = DEFAULT_START_DATE;
        EndDate = ExecutionServer.DateMaxValue;
      }
      ProductDataService.WriteProduct(this);
    }


    internal void Update(ProductFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Name = PatchCleanField(fields.Name, Name);
      Description = PatchCleanField(fields.Description, Description);
      InternalCode = PatchCleanField(fields.InternalCode, InternalCode);
      _tags = PatchField(string.Join(" ", fields.Tags), _tags);
      BaseUnit = PatchField(fields.BaseUnitUID, BaseUnit);
      Manager = PatchField(fields.ManagerUID, Manager);
    }

    #endregion Methods

  } // class Product

}  // namespace Empiria.Products
