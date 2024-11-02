/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Power type                              *
*  Type     : ProductType                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Power type that describes a product.                                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Linq;

using Empiria.Ontology;

namespace Empiria.Products {

  /// <summary>Power type that describes a product.</summary>
  [Powertype(typeof(Product))]
  public class ProductType : Powertype {

    #region Constructors and parsers

    protected ProductType() {
      // Empiria powertype types always have this constructor.
    }

    static public new ProductType Parse(int typeId) => Parse<ProductType>(typeId);

    static internal new ProductType Parse(string typeName) => Parse<ProductType>(typeName);

    static public ProductType Empty => Parse("ObjectTypeInfo.Product");

    static internal FixedList<ProductType> GetList() {
      return Empty.GetAllSubclasses()
                  .Select(x => (ProductType) x)
                  .ToFixedList();
    }

    #endregion Constructors and parsers

  }  // class ProductType

}  // namespace Empiria.Products
