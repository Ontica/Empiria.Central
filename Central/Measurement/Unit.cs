/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Measurement                                Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : General Object                          *
*  Type     : Unit                                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a unit of measure.                                                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Measurement {

  /// <summary>Represents a unit of measure.</summary>
  public class Unit : GeneralObject {

    #region Constructors and parsers

    protected Unit() {
      // Required by Empiria Framework.
    }

    static public Unit Parse(int id) => ParseId<Unit>(id);

    static public Unit Parse(string uid) => ParseKey<Unit>(uid);

    static public Unit Empty => ParseEmpty<Unit>();

    #endregion Constructors and parsers

    #region Properties

    public string PluralName {
      get {
        return base.ExtendedDataField.Get<string>("PluralName", string.Empty);
      }
    }


    public string Abbr {
      get {
        return base.ExtendedDataField.Get<string>("Abbr", string.Empty);
      }
    }


    public bool IsIndivisible {
      get {
        return base.ExtendedDataField.Get<bool>("IsIndivisible", false);
      }
    }


    public string Format {
      get {
        return base.ExtendedDataField.Get<string>("Format", string.Empty);
      }
    }

    #endregion Properties

  } // class Unit

} // namespace Empiria.Measurement
