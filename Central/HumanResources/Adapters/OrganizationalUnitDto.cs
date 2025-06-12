/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Output DTO                              *
*  Type     : OrganizationalStructureDto                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for organizational structure.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.StateEnums;

namespace Empiria.HumanResources {

  public class OrganizationalUnitDescriptor {

    public string UID {
      get; internal set;
    }

    public string Code {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public string FullName {
      get; internal set;
    }

    public string TypeName {
      get; internal set;
    }

    public string ResponsibleName {
      get; internal set;
    }

    public int Level {
      get; internal set;
    }

    public bool IsLastLevel {
      get; internal set;
    }

    public DateTime StartDate {
      get; internal set;
    }

    public DateTime EndDate {
      get; internal set;
    }

    public bool Obsolete {
      get; internal set;
    }

    public string StatusName {
      get; internal set;
    }

  }  // class OrganizationalUnitDto

}  // namespace Empiria.HumanResources
