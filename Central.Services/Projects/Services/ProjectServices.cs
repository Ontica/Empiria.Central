/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Services Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Services interactor class               *
*  Type     : ProjectServices                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for project instances.                                                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;
using Empiria.StateEnums;

using Empiria.Projects.Services.Adapters;

namespace Empiria.Projects.Services {

  /// <summary>Services for project instances.</summary>
  public class ProjectServices : Service {

    #region Constructors and parsers

    protected ProjectServices() {
      // no-op
    }

    static public ProjectServices ServiceInteractor() {
      return Service.CreateInstance<ProjectServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public ProjectDto CreateProject(ProjectFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var projectType = ProjectType.Parse(fields.ProjectTypeUID);

      Assertion.Require(projectType.Status != EntityStatus.Deleted,
                        "No es posible crear un proyecto con un tipo de proyecto " +
                        "que está marcado como eliminado.");

      var project = new Project(projectType, fields.Name);

      project.Update(fields);

      project.Save();

      return ProjectMapper.Map(project);
    }


    public ProjectDto DeleteProject(string projectUID) {
      Assertion.Require(projectUID, nameof(projectUID));

      var project = Project.Parse(projectUID);

      project.Delete();

      project.Save();

      return ProjectMapper.Map(project);
    }


    public FixedList<ProjectDto> GetProjectsList() {

      FixedList<Project> projects = Project.GetList();

      return ProjectMapper.Map(projects);
    }


    public ProjectDto UpdateProject(ProjectFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      var project = Project.Parse(fields.UID);

      project.Update(fields);

      project.Save();

      return ProjectMapper.Map(project);
    }

    #endregion Services

  }  // class ProjectServices

}  // namespace Empiria.Projects.Services
