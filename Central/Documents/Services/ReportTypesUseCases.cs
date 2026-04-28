/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Use cases Layer                         *
*  Assembly : Empiria.Central.dll                        Pattern   : Use case interactor class               *
*  Type     : ReportTypesUseCases                        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Use cases for report types searching and retriving.                                            *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

namespace Empiria.Documents.UseCases {

  /// <summary>Use cases for report types searching and retriving.</summary>
  public class ReportTypesUseCases : UseCase {

    #region Constructors and parsers

    protected ReportTypesUseCases() {
      // no-op
    }

    static public ReportTypesUseCases UseCaseInteractor() {
      return UseCase.CreateInstance<ReportTypesUseCases>();
    }

    #endregion Constructors and parsers

    #region Use cases

    public FixedList<ReportTypeDto> GetReportTypes() {
      FixedList<ReportType> reportTypes = ReportType.GetList();

      reportTypes = base.RestrictUserDataAccessTo(reportTypes);

      return ReportTypeMapper.Map(reportTypes);
    }

    #endregion Use cases

  }  // class ReportTypesUseCases

}  // namespace Empiria.Documents.UseCases
