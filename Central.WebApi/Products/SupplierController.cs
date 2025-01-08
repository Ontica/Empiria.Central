/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Parties                                      Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web api controller                    *
*  Type     : SupplierController                           License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Query web API used to retrive and update products suppliers.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

using Empiria.Parties;

namespace Empiria.Products.WebApi {

  /// <summary>Query web API used to retrive and update products suppliers.</summary>
  public class SupplierController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v8/parties/primary-party/suppliers-list")]
    public CollectionModel GetSuppliers([FromUri] string keywords = "") {

      FixedList<Party> suppliers = Party.GetPartiesInRole("supplier", keywords);

      return new CollectionModel(Request, suppliers.MapToNamedEntityList());
    }

    #endregion Query web apis

  }  // class SupplierController

}  // namespace Empiria.Products.WebApi
