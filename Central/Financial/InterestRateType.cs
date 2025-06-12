/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : InterestRateType                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents an interest rate type.                                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Represents an interest rate type.</summary>
  public class InterestRateType : CommonStorage {

    #region Constructors and parsers

    static public InterestRateType Parse(int id) => ParseId<InterestRateType>(id);

    static public InterestRateType Parse(string uid) => ParseKey<InterestRateType>(uid);

    static public InterestRateType Empty => ParseEmpty<InterestRateType>();

    static public FixedList<InterestRateType> GetList() {
      return GetStorageObjects<InterestRateType>();
    }

    #endregion Constructors and parsers

    #region Properties

    public new string Code {
      get {
        return base.Code;
      }
    }

    #endregion Properties

  } // class InterestRateType

} // namespace Empiria.Financial
