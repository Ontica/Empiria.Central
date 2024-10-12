/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                     Component : Web Api                               *
*  Assembly : Empiria.Central.WebApi.dll                   Pattern   : Web Api Controller                    *
*  Type     : ProjectTypeController                        License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Web API used to retrive and update project types.                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System.Web.Http;

using Empiria.WebApi;

using Empiria.Projects.Services;
using Empiria.Projects.Services.Adapters;

namespace Empiria.Projects.WebApi {

  /// <summary>Web API used to retrive and update project types.</summary>
  public class ProjectTypeController : WebApiController {

    #region Query web apis

    [HttpGet]
    [Route("v2/projects/project-types")]
    public CollectionModel GetProjectTypes() {

      using (var usecases = ProjectTypeServices.ServiceInteractor()) {
        FixedList<NamedEntityDto> list = usecases.GetProjectTypes();

        return new CollectionModel(base.Request, list);
      }
    }


    [HttpGet]
    [Route("v2/budgeting/project-types/{projectTypeUID:guid}/projects")]
    public CollectionModel GetProjectTypeProjects([FromUri] string projectTypeUID) {

      using (var usecases = ProjectServices.ServiceInteractor()) {
        FixedList<ProjectDto> projects = usecases.GetProjectTypeProjects(projectTypeUID);

        return new CollectionModel(base.Request, projects);
      }
    }

    #endregion Query web apis

    #region Command web apis

    [HttpPost]
    [Route("v2/projects/project-types")]
    public SingleObjectModel CreateProjectType([FromBody] NamedEntityFields fields) {

      base.RequireBody(fields);

      using (var usecases = ProjectTypeServices.ServiceInteractor()) {
        NamedEntityDto projectType = usecases.CreateProjectType(fields);

        return new SingleObjectModel(base.Request, projectType);
      }
    }

    #endregion Command web apis

  }  // class ProjectTypeController

}  // namespace Empiria.Projects.WebApi
