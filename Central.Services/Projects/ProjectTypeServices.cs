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
      Assertion.Require(fields, nameof(fields));

      var projectType = new ProjectType(fields.Name);

      projectType.Save();

      return projectType.MapToNamedEntity();
    }


    public void DeleteProjectType(string projectTypeUID) {
      Assertion.Require(projectTypeUID, nameof(projectTypeUID));

      var projectType = ProjectType.Parse(projectTypeUID);

      projectType.Delete();

      projectType.Save();
    }


    public FixedList<NamedEntityDto> GetProjectTypes() {
      return ProjectType.GetList()
                        .MapToNamedEntityList();
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
