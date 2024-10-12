/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Projects                                   Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Output DTO                              *
*  Type     : ProjectDto                                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for Project instances.                                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Projects.Services.Adapters {

  /// <summary>Output DTO for Project instances.</summary>
  public class ProjectDto {

    public string UID {
      get; internal set;
    }

    public string Code {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public string Description {
      get; internal set;
    }

    public NamedEntityDto ProjectType {
      get; internal set;
    }

  }  // class ProjectDto

}  // namespace Empiria.Projects.Services.Adapters
