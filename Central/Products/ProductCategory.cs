/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : ProductCategory                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a product category which holds products of the same kind or product type.           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Linq;

using Empiria.StateEnums;

namespace Empiria.Products {

  /// <summary>Represents a product category which holds products of the same kind or product type.</summary>
  public class ProductCategory : CommonStorage {

    #region Constructors and parsers

    protected ProductCategory() {
      // Required by Empiria Framework
    }

    internal ProductCategory(ProductType productType, string name) {
      Assertion.Require(productType, nameof(productType));

      name = EmpiriaString.Clean(name);

      Assertion.Require(name, nameof(name));

      ProductType = productType;
      Name = name;
    }

    static public ProductCategory Parse(int id) => ParseId<ProductCategory>(id);

    static public ProductCategory Parse(string uid) => ParseKey<ProductCategory>(uid);

    static public ProductCategory Empty => ParseEmpty<ProductCategory>();

    static public FixedList<ProductCategory> GetList() {
      return GetStorageObjects<ProductCategory>();
    }

    #endregion Constructors and parsers

    #region Properties

    public ProductType ProductType {
      get {
        return base.ExtData.Get("productTypeId", ProductType.Empty);
      }
      protected set {
        base.ExtData.SetIf("productTypeId", value.Id, value.Id != -1);
      }
    }

    public FixedList<ProductUnit> ProductUnits {
      get {
        return base.ExtData.GetFixedList<ProductUnit>("productUnits", false);
      }
      private set {
        base.ExtData.Set("productUnits", value);
      }
    }


    public bool IsAssignable {
      get {
        return base.ExtData.Get("isAssignable", IsEmptyInstance ? false : true);
      }
      protected set {
        base.ExtData.SetIf("isAssignable", value, value == false);
      }
    }


    public ProductCategory Parent {
      get {
        return base.GetParent<ProductCategory>();
      }
      private set {
        SetParent(value);
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(Name, ProductType.DisplayName,
                                           Parent.IsEmptyInstance ? string.Empty : Parent.Keywords);
      }
    }

    public EntityStatus Status {
      get {
        return base.GetStatus<EntityStatus>();
      }
    }

    #endregion Properties

    #region Methods

    internal void Delete() {
      base.SetStatus(EntityStatus.Deleted);
    }


    internal void Update(ProductCategoryFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Name = Patcher.PatchClean(fields.Name, Name);
      Description = Patcher.PatchClean(fields.Description, Description);
      Parent = Patcher.Patch(fields.ParentCategoryUID, Parent);
      IsAssignable = Patcher.Patch(fields.IsAssignable, IsAssignable);

      if (fields.ProductUnits.Length != 0) {
        ProductUnits = fields.ProductUnits.Select(x => ProductUnit.Parse(x))
                                          .ToFixedList();
      }
    }

    #endregion Methods

  } // class ProductCategory

} // namespace Empiria.Products
