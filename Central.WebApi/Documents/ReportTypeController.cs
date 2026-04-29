/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                    Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : ReportTypeController                         License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrieve Report Types information.                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Web.Http;

using Empiria.WebApi;

using Empiria.Documents.UseCases;

namespace Empiria.Documents.WebApi {

  /// <summary>Web API used to retrieve Report Types information.</summary>
  public class ReportTypeController : WebApiController {

    #region Web Apis

    [HttpGet]
    [Route("v2/documents/report-types/")]
    public CollectionModel GetReportTypes() {

      using (var useCase = ReportTypesUseCases.UseCaseInteractor()) {

        FixedList<ReportTypeDto> reportTypes = useCase.GetReportTypes();

        return new CollectionModel(base.Request, reportTypes);
      }
    }

    #endregion Web Apis

  }  // class ReportTypeController

}  // namespace Empiria.Documents.WebApi
