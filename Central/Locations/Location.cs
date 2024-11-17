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

namespace Empiria.Locations {

  /// <summary>Represents a physical location like a building, an office or work place, a store
  /// or a warehouse, etc. Locations are fractal objects with a parent and zero ore more children.</summary>
  public class Location : CommonStorage {

    #region Constructors and parsers

    static public Location Parse(int id) => ParseId<Location>(id);

    static public Location Parse(string uid) => ParseKey<Location>(uid);

    static public FixedList<Location> GetList() {
      return BaseObject.GetList<Location>()
                       .ToFixedList();
    }

    static public Location Empty => ParseEmpty<Location>();

    #endregion Constructors and parsers

    #region Properties

    public string Code {
      get {
        return base.Data.Code;
      }
      private set {
        base.Data.Code = EmpiriaString.Clean(value);
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(base.Keywords, Code);
      }
    }


    public LocationType LocationType {
      get {
        return LocationType.Parse(base.Data.ObjectClassificationId);
      }
      private set {
        base.Data.ObjectClassificationId = value.Id;
      }
    }


    public Location Parent {
      get {
        return Location.Parse(base.Data.ParentObjectId);
      }
      private set {
        base.Data.ParentObjectId = value.Id;
      }
    }

    #endregion Properties

  } // class Location

} // namespace Empiria.Locations
