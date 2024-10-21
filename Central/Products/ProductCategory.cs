/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : ProductCategory                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a product category which holds products of the same kind and product type.          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products {

  /// <summary>Represents a product category which holds products of the same kind and product type.</summary>
  public class ProductCategory : GeneralObject {

    #region Constructors and parsers

    static public ProductCategory Parse(int id) => ParseId<ProductCategory>(id);

    static public ProductCategory Parse(string uid) => ParseKey<ProductCategory>(uid);

    static public FixedList<ProductCategory> GetList() {
      return BaseObject.GetList<ProductCategory>()
                       .ToFixedList();
    }

    static public ProductCategory Empty => ParseEmpty<ProductCategory>();

    #endregion Constructors and parsers

    #region Properties

    public string Description {
      get {
        return base.ExtendedDataField.Get("description", string.Empty);
      }
      private set {
        base.ExtendedDataField.SetIfValue("description", EmpiriaString.TrimAll(value));
      }
    }


    public ProductType ProductType {
      get {
        return base.ExtendedDataField.Get("productTypeId", ProductType.Empty);
      }
      private set {
        base.ExtendedDataField.SetIf("productTypeId", value.Id, value.Id != -1);
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
        return base.ExtendedDataField.Get("isAssignable", false);
      }
      private set {
        base.ExtendedDataField.SetIf("isAssignable", value, value == false);
      }
    }

    public ProductCategory Parent {
      get {
        return base.ExtendedDataField.Get("parentCategoryId", ProductCategory.Empty);
      }
      private set {
        base.ExtendedDataField.SetIf("parentCategoryId", value.Id, value.Id != -1);
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(Name, Parent.Keywords, ProductType.DisplayName);
      }
    }

    #endregion Properties

  } // class ProductCategory

} // namespace Empiria.Products
