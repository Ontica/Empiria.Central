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

    static public Unit Parse(int id) {
      return ParseId<Unit>(id);
    }

    static public Unit Parse(string unitNamedKey) {
      return ParseKey<Unit>(unitNamedKey);
    }

    static public Unit Empty => ParseEmpty<Unit>();

    #endregion Constructors and parsers

    #region Properties

    [DataField(ExtensionDataFieldName + ".PluralName", IsOptional = true)]
    public string PluralName {
      get;
      private set;
    }


    [DataField(ExtensionDataFieldName + ".Abbr", IsOptional = true)]
    public string Abbr {
      get;
      private set;
    }


    [DataField(ExtensionDataFieldName + ".IsIndivisible", IsOptional = true)]
    public bool IsIndivisible {
      get;
      private set;
    }


    [DataField(ExtensionDataFieldName + ".Format", IsOptional = true)]
    public string Format {
      get;
      private set;
    }

    #endregion Properties

  } // class Unit

} // namespace Empiria.Measurement
