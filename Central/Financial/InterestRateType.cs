/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : General Object                          *
*  Type     : InterestRateType                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents an interest rate type.                                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Represents an interest rate type.</summary>
  public class InterestRateType : GeneralObject {

    #region Constructors and parsers

    private InterestRateType() {
      // Required by Empiria Framework.
    }

    static public InterestRateType Parse(int id) {
      return BaseObject.ParseId<InterestRateType>(id);
    }

    static public InterestRateType Parse(string uid) {
      return BaseObject.ParseKey<InterestRateType>(uid);
    }

    static public InterestRateType Empty => BaseObject.ParseEmpty<InterestRateType>();

    #endregion Constructors and parsers

  } // class InterestRateType

} // namespace Empiria.Financial
