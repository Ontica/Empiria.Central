﻿/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Parties                                    Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : OrganizationalUnit                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents an organizational unit that is a part of an organization.                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Parties {

  /// <summary>Represents an organizational unit that is a part of an organization.</summary>
  public class OrganizationalUnit : Party {

    #region Constructors and parsers

    protected OrganizationalUnit() {
      // Required by Empiria Framework.
    }

    protected OrganizationalUnit(PartyType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }


    static public new OrganizationalUnit Parse(int id) => ParseId<OrganizationalUnit>(id);

    static public new OrganizationalUnit Parse(string uid) => ParseKey<OrganizationalUnit>(uid);

    static public new OrganizationalUnit Empty => ParseEmpty<OrganizationalUnit>();

    #endregion Constructors and parsers

    #region Properties

    public string Acronym {
      get {
        return base.ExtendedData.Get("acronym", string.Empty);
      }
      private set {
        base.ExtendedData.SetIfValue("acronym", value);
      }
    }


    public string Code {
      get {
        return base.ExtendedData.Get("code", string.Empty);
      }
      private set {
        base.ExtendedData.SetIfValue("code", value);
      }
    }


    public string FullName {
      get {
        if (Code.Length > 0) {
          return $"{Code} - {Name}";
        } else {
          return Name;
        }
      }
    }

    #endregion Properties

  } // class OrganizationalUnit

} // namespace Empiria.Parties
