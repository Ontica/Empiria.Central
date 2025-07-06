/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Locations                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : Location                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a physical location like a building, an office or work place, a store               *
*             or a warehouse, etc. Locations are fractal objects with a parent and zero ore more children.   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using System.Collections.Generic;
using Empiria.Data;
using Empiria.Parties;

namespace Empiria.Locations {

  /// <summary>Represents a physical location like a building, an office or work place, a store
  /// or a warehouse, etc. Locations are fractal objects with a parent and zero ore more children.</summary>
  public class Location : CommonStorage {

    #region Constructors and parsers

    static public Location Parse(int id) => ParseId<Location>(id);

    static public Location Parse(string uid) => ParseKey<Location>(uid);

    static public FixedList<Location> GetList() {
      return GetStorageObjects<Location>();
    }

    static public Location Empty => ParseEmpty<Location>();

    #endregion Constructors and parsers

    #region Properties

    public string LocationCode {
      get {
        return base.Code;
      }
      private set {
        base.Code = EmpiriaString.Clean(value);
      }
    }


    public string FullName {
      get {
        if (Parent.IsEmptyInstance) {
          return Name;
        }
        return $"{Parent.FullName} {Name}";
      }
    }


    public bool IsLeaf {
      get {
        return GetChildren().Count == 0;
      }
    }


    public bool IsRoot {
      get {
        return Parent.IsEmptyInstance;
      }
    }

    public override string Keywords {
      get {
        if (this.IsEmptyInstance) {
          return String.Empty;
        }
        if (Parent.IsEmptyInstance) {
          return EmpiriaString.BuildKeywords(FullName, Code, LocationType.Keywords);
        } else {
          return EmpiriaString.BuildKeywords(FullName, Code, Parent.Keywords, LocationType.Keywords);
        }
      }
    }


    public int Level {
      get {
        if (IsEmptyInstance) {
          return 0;
        }
        if (IsRoot) {
          return 1;
        }
        return Parent.Level + 1;
      }
    }


    public LocationType LocationType {
      get {
        return base.GetCategory<LocationType>();
      }
      private set {
        base.SetCategory(value);
      }
    }


    public Location Parent {
      get {
        return base.GetParent<Location>();
      }
      private set {
        SetParent(value);
      }
    }

    #endregion Properties

    #region Methods

    public FixedList<Location> GetAllChildren() {
      if (this.IsEmptyInstance) {
        return new FixedList<Location>();
      }

      var result = new List<Location>(2000);

      foreach (var child in GetChildren()) {
        result.Add(child);
        result.AddRange(child.GetAllChildren());
      }

      return result.ToFixedList();
    }


    public FixedList<Location> GetChildren() {
      if (this.IsEmptyInstance) {
        return new FixedList<Location>();
      }
      return GetFullList<Location>($"PARENT_OBJECT_ID = {this.Id} AND OBJECT_STATUS <> 'X'", "OBJECT_NAME");
    }


    public FixedList<Location> GetLeafChildren() {
      if (this.IsEmptyInstance) {
        return new FixedList<Location>();
      }
      return GetAllChildren().FindAll(x => x.IsLeaf);
    }


    public Location SeekTree(LocationType locationType) {
      if (this.IsEmptyInstance) {
        return Empty;
      }
      if (this.LocationType.Equals(locationType)) {
        return this;
      }
      if (this.IsRoot) {
        return Empty;
      }
      return Parent.SeekTree(locationType);
    }

    internal void Clean() {
      if (IsEmptyInstance) {
        return;
      }
      var sql = "UPDATE COMMON_STORAGE " +
                $"SET OBJECT_UID = '{Guid.NewGuid().ToString()}', " +
                $"OBJECT_HISTORIC_ID = {Id}, " +
                $"OBJECT_KEYWORDS = '{this.Keywords}', " +
                $"OBJECT_START_DATE = {DataCommonMethods.FormatSqlDbDate(new DateTime(2025, 06, 25))}, " +
                $"OBJECT_POSTING_TIME = {DataCommonMethods.FormatSqlDbDate(new DateTime(2025, 06, 25))}, " +
                $"OBJECT_END_DATE = {DataCommonMethods.FormatSqlDbDate(new DateTime(2078, 12, 31))} " +
                $"WHERE OBJECT_ID = {Id}";

      var op = DataOperation.Parse(sql);

      DataWriter.Execute(op);
    }

    #endregion Methods

  } // class Location

} // namespace Empiria.Locations
