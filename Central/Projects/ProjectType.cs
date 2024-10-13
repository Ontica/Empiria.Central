/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : ProjectType                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes a project type.                                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.StateEnums;

namespace Empiria.Projects {

  /// <summary>Describes a project type.</summary>
  public class ProjectType : GeneralObject {

    #region Constructors and parsers

    private ProjectType() {
      // Required by Empiria Framework.
    }

    public ProjectType(string name) {
      Assertion.Require(name, nameof(name));

      Update(name);
    }

    static public ProjectType Parse(int typeId) => ParseId<ProjectType>(typeId);

    static public ProjectType Parse(string typeUID) => ParseKey<ProjectType>(typeUID);

    static public FixedList<ProjectType> GetList() {
      return BaseObject.GetList<ProjectType>()
                       .ToFixedList();
    }

    static public ProjectType Empty => ParseEmpty<ProjectType>();

    #endregion Constructors and parsers

    #region Methods

    public FixedList<Project> GetProjects() {
      return BaseObject.GetList<Project>()
                       .ToFixedList()
                       .FindAll(x => x.ProjectType.Equals(this));
    }

    internal void Delete() {
      base.Status = EntityStatus.Deleted;

      base.MarkAsDirty();
    }


    internal void Update(string name) {
      name = EmpiriaString.Clean(name);

      Assertion.Require(name, nameof(name));

      this.Name = name;

      base.MarkAsDirty();
    }

    #endregion Methods

  }  // class ProjectType

}  // Empiria.Projects
