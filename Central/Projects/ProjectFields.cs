/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Input Fields DTO                        *
*  Type     : ProjectFields                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input fields DTO used for update project's information.                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Projects {

  /// <summary>Input fields DTO used for update project's information.</summary>
  public class ProjectFields : NamedEntityFields {

    public string ProjectTypeUID {
      get; set;
    }

    public string Code {
      get; set;
    }

    public string Description {
      get; set;
    }

  }  // class ProjectFields



  /// <summary>Extension methods for ProjectFields type.</summary>
  static internal class ProjectFieldsExtensions {

    static internal void EnsureValid(this ProjectFields fields) {
      if (fields.ProjectTypeUID.Length != 0) {
        _ = fields.GetProjectType();
      }
    }

    static internal ProjectType GetProjectType(this ProjectFields fields) {
      return ProjectType.Parse(fields.ProjectTypeUID);
    }

  }  // class ProjectFieldsExtensions

}  // namespace Empiria.Projects
