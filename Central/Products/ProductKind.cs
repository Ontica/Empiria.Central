/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : ProductKind                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a product kind.                                                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products {

  /// <summary>Represents a product kind.</summary>
  public class ProductKind : GeneralObject {

    #region Constructors and parsers

    static public ProductKind Parse(int id) => ParseId<ProductKind>(id);

    static public ProductKind Parse(string uid) => ParseKey<ProductKind>(uid);

    static public FixedList<ProductKind> GetList() {
      return BaseObject.GetList<ProductKind>()
                       .ToFixedList();
    }

    static public ProductKind Empty => ParseEmpty<ProductKind>();

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

    public ProductKind Parent {
      get {
        return base.ExtendedDataField.Get("parentKindId", ProductKind.Empty);
      }
      private set {
        base.ExtendedDataField.SetIf("productKindId", value.Id, value.Id != -1);
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(Name, Parent.Keywords, ProductType.DisplayName);
      }
    }

    #endregion Properties

  } // class ProductKind

} // namespace Empiria.Products
