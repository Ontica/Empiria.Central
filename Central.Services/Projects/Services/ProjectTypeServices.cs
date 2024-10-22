/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : ProjectTypeServices                        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides services for ProyectType instances.                                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Projects.Services.Adapters;

namespace Empiria.Projects.Services {

  /// <summary>Provides services for ProyectType instances.</summary>
  public class ProjectTypeServices : Service {

    #region Constructors and parsers

    protected ProjectTypeServices() {
      // no-opcontra
    }

    static public ProjectTypeServices ServiceInteractor() {
      return Service.CreateInstance<ProjectTypeServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public NamedEntityDto CreateProjectType(NamedEntityFields fields) {

      fields.Name = EmpiriaString.Clean(fields.Name);

      Assertion.Require(fields, nameof(fields));

      var projectType = new ProjectType(fields.Name);

      projectType.Save();

      return projectType.MapToNamedEntity();
    }


    public NamedEntityDto DeleteProjectType(string projectTypeUID) {
      Assertion.Require(projectTypeUID, nameof(projectTypeUID));

      var projectType = ProjectType.Parse(projectTypeUID);

      Assertion.Require(!projectType.HasProjects,
                        "No se puede eliminar el tipo de proyecto debido a que tiene proyectos asignados");

      projectType.Delete();

      projectType.Save();

      return projectType.MapToNamedEntity();
    }


    public FixedList<NamedEntityDto> GetProjectTypes() {
      return ProjectType.GetList()
                        .MapToNamedEntityList();
    }


    public FixedList<ProjectDto> GetProjectTypeProjects(string projectTypeUID) {
      Assertion.Require(projectTypeUID, nameof(projectTypeUID));

      var projectType = ProjectType.Parse(projectTypeUID);

      FixedList<Project> values = projectType.GetProjects();

      return ProjectMapper.Map(values);
    }


    public NamedEntityDto UpdateProjectType(NamedEntityFields fields) {
      Assertion.Require(fields, nameof(fields));

      var projectType = ProjectType.Parse(fields.UID);

      projectType.Update(fields.Name);

      projectType.Save();

      return projectType.MapToNamedEntity();
    }

    #endregion Services

  }  // class ProjectTypeServices

}  // namespace Empiria.Projects.Services
