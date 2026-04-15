/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : CreditProjectType                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes a project type as the purpose of a credit.                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Describes a project type as the purpose of a credit.</summary>
  public class CreditProjectType : CommonStorage {

    #region Constructors and parsers

    static public CreditProjectType Parse(int id) => ParseId<CreditProjectType>(id);

    static public CreditProjectType Parse(string uid) => ParseKey<CreditProjectType>(uid);

    static public CreditProjectType Empty => ParseEmpty<CreditProjectType>();

    static public FixedList<CreditProjectType> GetList() {
      return GetStorageObjects<CreditProjectType>();
    }

    static public CreditProjectType TryParseWithID(string objectCode) {
      Assertion.Require(objectCode, nameof(objectCode));

      var creditProjectType = TryParse<CreditProjectType>($"OBJECT_CODE = '{objectCode}' AND OBJECT_TYPE_ID = 293");

      if (creditProjectType == null) {
        return null;
      }

      return (CreditProjectType) creditProjectType;
    }

    #endregion Constructors and parsers

  } // class CreditProjectType

} // namespace Empiria.Financial
