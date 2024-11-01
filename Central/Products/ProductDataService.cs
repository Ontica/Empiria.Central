/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products                                   Component : Data Access Layer                       *
*  Assembly : Empiria.Central.dll                        Pattern   : Data service                            *
*  Type     : ProductDataService                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides products data persistence services.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;

namespace Empiria.Products {

  /// <summary>Provides products data persistence services.</summary>
  static internal class ProductDataService {

    static internal FixedList<Product> SearchProducts(string filter, string sort) {
      Assertion.Require(filter, nameof(filter));
      Assertion.Require(sort, nameof(sort));

      var sql = "SELECT * FROM PMS_PRODUCTS " +
               $"WHERE {filter} " +
               $"ORDER BY {sort}";

      var op = DataOperation.Parse(sql);

      return DataReader.GetFixedList<Product>(op);
    }


    static internal void WriteProduct(Product o) {
      var op = DataOperation.Parse("write_PMS_PRODUCT", o.Id, o.UID,
                  o.ProductType.Id, o.ProductCategory.Id, o.Name, o.Description,
                  o.InternalCode, string.Join(" ", o.Tags), o.Attributes.ToString(),
                  o.BillingData.ToString(), o.BudgetingData.ToString(),
                  o.BaseUnit.Id, o.Manager.Id, o.ExtensionData.ToString(),
                  o.Keywords, o.StartDate, o.EndDate, (char) o.Status);

      DataWriter.Execute(op);
    }

  }  // class ProductDataService

}  // namespace Empiria.Products
