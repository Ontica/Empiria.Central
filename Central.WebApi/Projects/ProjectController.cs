/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Projects                                     Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : ProjectController                            License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update projects.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Projects.Services;
using Empiria.Projects.Services.Adapters;

namespace Empiria.Projects.WebApi {

  /// <summary>Web API used to retrive and update projects.</summary>
  public class ProjectController : WebApiController {

    #region Web Apis

    [HttpGet]
    [Route("v2/projects")]
    public CollectionModel GetProjects() {

      using (var usecases = ProjectServices.ServiceInteractor()) {
        FixedList<ProjectDto> projects = usecases.GetProjectsList();

        return new CollectionModel(base.Request, projects);
      }
    }

    #endregion Web Apis

  }  // class ProjectController

}  // namespace Empiria.Projects.WebApi
