/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Documents                                     Component : Interface adapters                   *
*  Assembly : Empiria.Central.dll                           Pattern   : Mapper class                         *
*  Type     : ReportTypeMapper                              License   : Please read LICENSE.txt file         *
*                                                                                                            *
*  Summary  : Methods used to map ReportType instances.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Documents {

  /// <summary>Methods used to map ReportType instances.</summary>
  static internal class ReportTypeMapper {

    static internal FixedList<ReportTypeDto> Map(FixedList<ReportType> reportList) {
      return reportList.Select(x => Map(x))
                      .ToFixedList();
    }


    static private ReportTypeDto Map(ReportType reportType) {
      return new ReportTypeDto {
        UID = reportType.UID,
        Name = reportType.Name,
        Group = reportType.Group,
        Controller = reportType.Controller,
      };
    }

  }  // class ReportTypeMapper

}  // namespace Empiria.Documents
