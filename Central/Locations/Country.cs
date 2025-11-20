/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Locations                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : Country                                    License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a country.                                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Locations {

  /// <summary>Represents a country.</summary>
  public class Country : CommonStorage {

    #region Constructors and parsers

    static public Country Parse(int id) => ParseId<Country>(id);

    static public Country Parse(string uid) => ParseKey<Country>(uid);

    static public FixedList<Country> GetList() {
      return GetStorageObjects<Country>();
    }

    static public Country Empty => ParseEmpty<Country>();

    #endregion Constructors and parsers

    #region Properties

    public string CountryCode {
      get {
        return base.Code;
      }
      private set {
        base.Code = EmpiriaString.Clean(value);
      }
    }

    #endregion Properties

  } // class Country

} // namespace Empiria.Locations
