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
  public class ProductCategory : GeneralObject {

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

    static public FixedList<ProductCategory> GetList() {
      return BaseObject.GetList<ProductCategory>()
                       .ToFixedList();
    }

    static public ProductCategory Empty => ParseEmpty<ProductCategory>();

    #endregion Constructors and parsers

    #region Properties

    public ProductType ProductType {
      get {
        return base.ExtendedDataField.Get("productTypeId", ProductType.Empty);
      }
      protected set {
        base.ExtendedDataField.SetIf("productTypeId", value.Id, value.Id != -1);
      }
    }


    public string Description {
      get {
        return base.ExtendedDataField.Get("description", string.Empty);
      }
      protected set {
        base.ExtendedDataField.SetIfValue("description", EmpiriaString.TrimAll(value));
      }
    }


    public FixedList<ProductUnit> ProductUnits {
      get {
        return base.ExtendedDataField.GetFixedList<ProductUnit>("productUnits", false);
      }
      private set {
        base.ExtendedDataField.Set("productUnits",  value);
      }
    }


    public bool IsAssignable {
      get {
        return base.ExtendedDataField.Get("isAssignable", IsEmptyInstance ? false : true);
      }
      protected set {
        base.ExtendedDataField.SetIf("isAssignable", value, value == false);
      }
    }


    public ProductCategory Parent {
      get {
        return base.ExtendedDataField.Get("parentCategoryId", ProductCategory.Empty);
      }
      protected set {
        base.ExtendedDataField.SetIf("parentCategoryId", value.Id, value.Id != -1);
      }
    }


    public override string Keywords {
      get {
        if (this.IsEmptyInstance) {
          return string.Empty;
        }
        return EmpiriaString.BuildKeywords(Name, ProductType.DisplayName, Parent.Keywords);
      }
    }

    #endregion Properties

    #region Methods

    internal void Delete() {
      base.Status = EntityStatus.Deleted;
    }


    internal void Update(ProductCategoryFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Name = PatchField(fields.Name, Name);
      Description = PatchField(fields.Description, Description);
      Parent = PatchField(fields.ParentCategoryUID, Parent);
      IsAssignable = PatchField(fields.IsAssignable, IsAssignable);

      if (fields.ProductUnits.Length != 0) {
        ProductUnits = fields.ProductUnits.Select(x => ProductUnit.Parse(x))
                                          .ToFixedList();
      }
    }

    #endregion Methods

  } // class ProductCategory

} // namespace Empiria.Products
