/* Empiria Central *******************************************************************************************
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
    [Route("v8/projects")]
    public CollectionModel GetProjects([FromUri] string keywords = "") {

      using (var services = ProjectServices.ServiceInteractor()) {
        FixedList<ProjectDto> projects = services.GetProjectsList();

        return new CollectionModel(base.Request, projects);
      }
    }


    #endregion Web Apis

    #region Command web apis

    [HttpPost]
    [Route("v8/projects")]
    public SingleObjectModel CreateProject([FromBody] ProjectFields fields) {

      base.RequireBody(fields);

      using (var service = ProjectServices.ServiceInteractor()) {
        ProjectDto project = service.CreateProject(fields);

        return new SingleObjectModel(base.Request, project);
      }
    }


    [HttpDelete]
    [Route("v8/projects/{projectUID:guid}")]
    public NoDataModel DeleteProject([FromUri] string projectUID) {

      using (var service = ProjectServices.ServiceInteractor()) {
        _ = service.DeleteProject(projectUID);

        return new NoDataModel(base.Request);
      }
    }


    [HttpPut, HttpPatch]
    [Route("v8/projects/{projectUID:guid}")]
    public SingleObjectModel UpdateProject([FromUri] string projectUID,
                                           [FromBody] ProjectFields fields) {

      base.RequireBody(fields);

      Assertion.Require(projectUID == fields.UID, "projectUID mismatch.");

      using (var service = ProjectServices.ServiceInteractor()) {
        ProjectDto project = service.UpdateProject(fields);

        return new SingleObjectModel(base.Request, project);
      }
    }

    #endregion Command web apis

  }  // class ProjectController

}  // namespace Empiria.Projects.WebApi
