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

namespace Empiria.HumanResources.Adapters {

  /// <summary>Output Holder DTO for an organizational unit structure.</summary>
  public class OrganizationalStructureHolder {

    public OrganizationalUnitDto OrganizationalUnit {
      get; internal set;
    }

    public FixedList<AccountabilityDescriptor> Accountabilities {
      get; internal set;
    }

  } // class OrganizationalStructureHolder



  /// <summary>Output DTO for an organizational unit.</summary>
  public class OrganizationalUnitDto {

    public string UID {
      get; internal set;
    }

    public string Code {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public NamedEntityDto Type {
      get; internal set;
    }

    public NamedEntityDto Parent {
      get; internal set;
    }

    public NamedEntityDto Responsible {
      get; internal set;
    }

    public DateTime StartDate {
      get; internal set;
    }

    public DateTime EndDate {
      get; internal set;
    }

  }  // class OrganizationalUnitDto



  /// <summary>Output DTO for an organizational unit for use in lists.</summary>
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

    public string ParentName {
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

  }  // class OrganizationalUnitDescriptor

}  // namespace Empiria.HumanResources.Adapters
