/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Time                                       Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Type Extension                          *
*  Type     : DateTimeExtensions                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Extension methods for DateTime variables.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Time {

  /// <summary>Extension methods for DateTime variables.</summary>
  static public class DateTimeExtensions {

    #region Public methods

    static public bool IsWeekendDate(this DateTime date) {
      return IsWeekendDate(date, EmpiriaCalendar.Default);
    }

    static public bool IsWeekendDate(this DateTime date, EmpiriaCalendar calendar) {
      return calendar.IsWeekendDay(date);
    }

    static public bool IsNonWorkingDate(this DateTime date) {
      return IsNonWorkingDate(date, EmpiriaCalendar.Default);
    }

    static public bool IsNonWorkingDate(this DateTime date, EmpiriaCalendar calendar) {
      Assertion.Require(calendar, "calendar");

      return (calendar.IsWeekendDay(date) || calendar.IsHoliday(date));
    }

    #endregion Public methods

  }  // class DateTimeExtensions

} // namespace Empiria.Time
