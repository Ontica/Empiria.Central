/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : ReportType                                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a type of report that contains different types of reports.                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Documents {

  /// <summary> Represents a type of report that contains different types of reports.</summary>
  public class ReportType : CommonStorage {

    #region Constructors and parsers

    protected ReportType() {
      // Required by Empiria Framework
    }

    static public ReportType Parse(int id) => ParseId<ReportType>(id);

    static public ReportType Parse(string uid) => ParseKey<ReportType>(uid);

    static public ReportType ParseWithNameKey(string namedKey) => ParseNamedKey<ReportType>(namedKey);

    static public ReportType Empty => ParseEmpty<ReportType>();

    static public FixedList<ReportType> GetList() {
      return GetStorageObjects<ReportType>();
    }

    #endregion Constructors and parsers

    #region Properties

    public string Controller {
      get {
        return base.ExtData.Get<string>("controller", string.Empty);
      }
      protected set {
        base.ExtData.Set("controller", value);
      }
    }


    public string Group {
      get {
        return base.ExtData.Get<string>("group", string.Empty);
      }
      protected set {
        base.ExtData.Set("group", value);
      }
    }


    public new string NamedKey {
      get {
        return base.NamedKey;
      }
      private set {
        base.NamedKey = value;
      }
    }

    #endregion Properties   

  } // class ReportType

} // namespace Empiria.Documents
