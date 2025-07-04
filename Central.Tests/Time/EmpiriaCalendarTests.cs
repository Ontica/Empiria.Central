﻿/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Time                                       Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : EmpiriaCalendarTests                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for EmpiriaCalendar type.                                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using System;

using Empiria.Time;

namespace Empiria.Tests.Time {

  /// <summary>Unit tests for EmpiriaCalendar type.</summary>
  public class EmpiriaCalendarTests {

    [Theory]
    [InlineData("2024-12-30", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 17, 18, 240, 511 })]
    [InlineData("2023-01-01", new int[] { 0, 1, 2, 3, 77, 78, 79, 80, 1320 })]
    [InlineData("2025-10-23", new int[] { 0, 1, 2, 3, 45, 133, 240, 580, 1200, 1432 })]
    [InlineData("2026-03-03", new int[] { 10, 3570, 7800, 10000, 13750, 45000 })]
    public void Should_Add_Working_Days(string dateString, int[] daysToAdd) {
      var calendar = EmpiriaCalendar.Default;

      var baseDate = DateTime.Parse(dateString);

      foreach (var days in daysToAdd) {
        DateTime calculatedDate = calendar.AddWorkingDays(baseDate, days);

        int actual = calculatedDate.Subtract(baseDate).Days;

        int expected = calendar.WorkingDays(baseDate, calculatedDate) +
                       calendar.NonWorkingDays(baseDate, calculatedDate);

        Assert.Equal(expected, actual);
      }
    }


    [Fact]
    public void Should_Handle_Non_Working_Days_Exceptions() {
      var calendar = EmpiriaCalendar.Default;

      Assert.True(calendar.IsNonWorkingDate(ToDate("2024-01-01")));
      Assert.False(calendar.IsNonWorkingDate(ToDate("2024-01-02")));
      Assert.True(calendar.IsNonWorkingDate(ToDate("2024-01-06")));
    }


    [Fact]
    public void Should_Handle_Non_Working_Days_Periods() {
      var calendar = EmpiriaCalendar.Default;

      Assert.True(calendar.IsNonWorkingDate(ToDate("2024-01-01")));
    }


    [Fact]
    public void Should_Handle_WeekendDays() {
      var calendar = EmpiriaCalendar.Default;

      Assert.False(calendar.IsWeekendDay(ToDate("2025-01-01")));
      Assert.True(calendar.IsWeekendDay(ToDate("2025-01-04")));
      Assert.True(calendar.IsWeekendDay(ToDate("2025-01-05")));
    }


    [Fact]
    public void Should_Read_Stored_Calendar_Holidays() {
      var calendar = EmpiriaCalendar.Default;

      Assert.Contains(calendar.Holidays, x => x.Equals(ToDate("2024-01-01")));
      Assert.Contains(calendar.Holidays, x => x.Equals(ToDate("2024-09-16")));
    }


    [Fact]
    public void Should_Read_WeekendDays() {
      var calendar = EmpiriaCalendar.Default;

      Assert.Contains(calendar.WeekendDays, x => x.Equals(DayOfWeek.Sunday));
      Assert.DoesNotContain(calendar.WeekendDays, x => x.Equals(DayOfWeek.Wednesday));
    }


    [Theory]
    [InlineData("2024-12-30", new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 17, 18, 240, 511 })]
    [InlineData("2023-01-01", new int[] { 0, 1, 2, 3, 77, 78, 79, 80, 1320 })]
    [InlineData("2025-10-23", new int[] { 0, 1, 2, 3, 45, 133, 240, 580, 1200, 1432 })]
    [InlineData("2026-03-03", new int[] { 10, 3570, 7800, 10000, 13750, 45000 })]
    public void Should_Substract_Working_Days(string dateString, int[] daysToSubstract) {
      var calendar = EmpiriaCalendar.Default;

      var baseDate = DateTime.Parse(dateString);

      foreach (var days in daysToSubstract) {
        DateTime calculatedDate = calendar.SubstractWorkingDays(baseDate, days);

        int calendarDays = baseDate.Subtract(calculatedDate).Days;

        int expected = calendar.WorkingDays(calculatedDate, baseDate) +
                       calendar.NonWorkingDays(calculatedDate, baseDate);

        Assert.Equal(expected, calendarDays);
      }
    }

    #region Helpers

    private DateTime ToDate(string dateString) {
      return DateTime.Parse(dateString).Date;
    }

    #endregion Helpers

  }  // EmpiriaCalendarTests

}  // namespace Empiria.Tests.Time
