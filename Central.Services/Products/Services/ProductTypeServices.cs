/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : ProductTypeServices                        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for ProductType instances.                                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

namespace Empiria.Products.Services {

  /// <summary>Services for ProductType instances.</summary>
  public class ProductTypeServices : Service {

    #region Constructors and parsers

    protected ProductTypeServices() {
      // no-op
    }

    static public ProductTypeServices ServiceInteractor() {
      return Service.CreateInstance<ProductTypeServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public FixedList<NamedEntityDto> GetProductTypes() {

      FixedList<ProductType> productTypes = ProductType.GetList();

      return productTypes.MapToNamedEntityList();
    }

    #endregion Services

  }  // class ProductTypeServices

}  // namespace Empiria.Products.Services
