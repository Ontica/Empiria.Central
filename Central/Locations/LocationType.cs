/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Locations                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : LocationType                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes a location type like warehouse, building, office, workarea, store, etc.              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Locations {

  /// <summary>Describes a location type like warehouse, building, office, workarea, store, etc.</summary>
  public class LocationType : CommonStorage {

    #region Constructors and parsers

    protected LocationType() {
      // Required by Empiria Framework
    }

    static public LocationType Parse(int id) => ParseId<LocationType>(id);

    static public LocationType Parse(string uid) => ParseKey<LocationType>(uid);

    static public FixedList<LocationType> GetList() {
      return BaseObject.GetList<LocationType>()
                       .ToFixedList();
    }

    static public LocationType Empty => ParseEmpty<LocationType>();

    #endregion Constructors and parsers

  } // class LocationType

} // namespace Empiria.Locations
