/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.Core.dll                   Pattern   : Information Holder                      *
*  Type     : Project                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Holds basic information about a project.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.StateEnums;

namespace Empiria.Projects {

  /// <summary>Holds basic information about a project.</summary>
  public class Project : GeneralObject {

    #region Constructors and parsers

    private Project() {
      // Required by Empiria Framework.
    }

    internal Project(ProjectType projectType, string name) {
      Assertion.Require(projectType, nameof(projectType));
      Assertion.Require(projectType.Status != EntityStatus.Deleted, "projectType has deleted status.");

      name = EmpiriaString.Clean(name);

      Assertion.Require(name, nameof(name));

      this.ProjectType = projectType;
      this.Name = name;
    }

    static public Project Parse(int id) => ParseId<Project>(id);

    static public Project Parse(string typeUID) => ParseKey<Project>(typeUID);

    static public FixedList<Project> GetList() {
      return BaseObject.GetList<Project>()
                       .ToFixedList()
                       .FindAll(x => x.Status != EntityStatus.Deleted);
    }

    static public Project Empty => ParseEmpty<Project>();

    #endregion Constructors and parsers

    #region Properties

    public ProjectType ProjectType {
      get {
        if (this.IsEmptyInstance) {
          return ProjectType.Empty;
        }
        return ExtendedDataField.Get<ProjectType>("projectTypeId");
      }
      private set {
        if (this.IsEmptyInstance) {
          return;
        }
        ExtendedDataField.Set("projectTypeId", value.Id);
      }
    }


    public string Code {
      get {
        return ExtendedDataField.Get("code", string.Empty);
      }
      private set {
        ExtendedDataField.SetIfValue("code", value);
      }
    }


    public string Description {
      get {
        return ExtendedDataField.Get("description", string.Empty);
      }
      private set {
        ExtendedDataField.SetIfValue("description", value);
      }
    }

    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(Name, Code, ProjectType.Name, Description);
      }
    }

    #endregion Properties

    #region Methods

    internal void Delete() {
      this.Status = EntityStatus.Deleted;

      MarkAsDirty();
    }


    internal void Update(ProjectFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      ProjectType = PatchField(fields.ProjectTypeUID, this.ProjectType);
      Code = PatchCleanField(fields.Code, this.Code);
      Name = PatchCleanField(fields.Name, this.Name);
      Description = PatchCleanField(fields.Description, this.Description);

      MarkAsDirty();
    }

    #endregion Methods

  }  // class Project

}  // namespace Empiria.Projects
