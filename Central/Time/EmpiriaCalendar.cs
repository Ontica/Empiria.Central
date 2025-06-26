/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Time                                       Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : EmpiriaCalendar                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides calendar data to know working and non working days.                                   *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Json;

namespace Empiria.Time {

  /// <summary>Provides calendar data to know working and non working days.</summary>
  public class EmpiriaCalendar {

    #region Constructors and parsers

    public EmpiriaCalendar(string calendarName, JsonObject json) {
      Assertion.Require(json, "json");

      this.Name = calendarName;
      this.LoadJsonData(json);
    }


    static public EmpiriaCalendar Parse(string calendarName) {
      Assertion.Require(calendarName, "calendarName");

      var storedJson = StoredJson.Parse("System.Calendars");

      JsonObject json = storedJson.Value.Slice(calendarName, true);

      return new EmpiriaCalendar(calendarName, json);
    }


    static public EmpiriaCalendar ParseOrDefault(string calendarName) {
      Assertion.Require(calendarName, "calendarName");

      if (Exists(calendarName)) {
        return Parse(calendarName);
      } else {
        return Default;
      }
    }


    static public bool Exists(string calendarName) {
      Assertion.Require(calendarName, "calendarName");

      var storedJson = StoredJson.Parse("System.Calendars");

      return storedJson.Value.Contains(calendarName);
    }


    static public EmpiriaCalendar Default {
      get {
        var calendarName = ConfigurationData.Get<string>("Default.Calendar.Name", "Default");

        return Parse(calendarName);
      }
    }

    #endregion Constructors and parsers

    #region Properties

    public string Name {
      get;
    }


    public FixedList<DateTime> Holidays {
      get; private set;
    }


    public FixedList<TimePeriod> NonWorkingDaysPeriods {
      get; private set;
    }


    public FixedList<DateTime> NonWorkingDaysExceptions {
      get; private set;
    }


    public FixedList<DayOfWeek> WeekendDays {
      get; private set;
    }

    #endregion Properties

    #region Methods

    public DateTime AddWorkingDays(DateTime date, int days) {
      Assertion.Require(days >= 0, "'days' parameter must be a non-negative number.");

      int workingDaysCounter = 0;
      DateTime datePointer = date.Date;

      while (true) {

        if (workingDaysCounter == days) {
          return datePointer;
        } else {
          datePointer = datePointer.AddDays(1);
        }

        if (IsWorkingDate(datePointer)) {
          workingDaysCounter++;
        }

      }  // while

    }


    public bool IsHoliday(DateTime date) {
      return this.Holidays.Contains(date.Date);
    }

    public bool IsHolidayOrWeekendDay(DateTime date) {
      return (this.Holidays.Contains(date.Date) || this.IsWeekendDay(date.Date));
    }

    public bool IsNonWorkingDate(DateTime date) {
      return !IsWorkingDate(date);
    }


    public bool IsWeekendDay(DateTime date) {
      return WeekendDays.Contains(date.DayOfWeek);
    }


    public bool IsWorkingDate(DateTime date) {
      if (IsNonWorkingDateException(date)) {
        return true;
      }
      if (IncludedInANonWorkingDaysPeriod(date)) {
        return false;
      }
      if (IsHoliday(date) || IsWeekendDay(date)) {
        return false;
      }
      return true;
    }


    public DateTime LastNonHolidayOrWeekendDate(DateTime date, bool includeDate = false) {
      date = date.Date;

      if (!includeDate) {
        date = date.AddDays(-1);
      }

      while (true) {
        if (!this.IsHolidayOrWeekendDay(date)) {
          return date;
        } else {
          date = date.AddDays(-1);
        }
      }
    }


    public DateTime LastNonWeekendDate(DateTime date, bool includeDate = false) {
      date = date.Date;

      if (!includeDate) {
        date = date.AddDays(-1);
      }

      while (true) {
        if (!this.IsWeekendDay(date)) {
          return date;
        } else {
          date = date.AddDays(-1);
        }
      }
    }


    public DateTime LastWorkingDate(DateTime date, bool includeDate = false) {
      date = date.Date;

      if (!includeDate) {
        date = date.AddDays(-1);
      }

      while (true) {
        if (this.IsWorkingDate(date)) {
          return date;
        } else {
          date = date.AddDays(-1);
        }
      }
    }


    public DateTime LastWorkingDateWithinMonth(int year, int month) {
      var date = new DateTime(year, month, DateTime.DaysInMonth(year, month));

      var lastWorkingDate = this.LastWorkingDate(date, true);

      if (lastWorkingDate.Month == month) {
        return lastWorkingDate;
      }

      lastWorkingDate = LastNonHolidayOrWeekendDate(date, true);

      if (lastWorkingDate.Month == month) {
        return lastWorkingDate;
      }

      return LastNonWeekendDate(date, true);
    }


    public DateTime NextWorkingDate(DateTime date, bool includeDate = false) {
      date = date.Date;

      if (!includeDate) {
        date = date.AddDays(1);
      }

      while (true) {
        if (this.IsWorkingDate(date)) {
          return date;
        } else {
          date = date.AddDays(1);
        }
      }
    }


    public int NonWorkingDays(DateTime from, DateTime to) {
      Assertion.Require(from <= to, "'from' parameter must be earlier or equal than 'to' parameter.");

      from = from.Date;
      to = to.Date;

      int nonWorkingDaysCounter = 0;
      DateTime datePointer = from;

      while (true) {

        if (datePointer == to) {
          return nonWorkingDaysCounter;
        } else {
          datePointer = datePointer.AddDays(1);
        }

        if (IsNonWorkingDate(datePointer)) {
          nonWorkingDaysCounter++;
        }

      }  // while
    }


    public DateTime SubstractWorkingDays(DateTime date, int days) {
      Assertion.Require(0 <= days, "'days' parameter must be a non-negative number.");

      int workingDaysCounter = 0;
      DateTime datePointer = date.Date;

      while (true) {

        if (workingDaysCounter == -1 * days) {
          return datePointer;
        } else {
          datePointer = datePointer.AddDays(-1);
        }

        if (IsWorkingDate(datePointer)) {
          workingDaysCounter--;
        }

      }  // while

    }


    public int WorkingDays(DateTime from, DateTime to) {
      Assertion.Require(from <= to, "'from' parameter must be earlier or equal than 'to' parameter.");

      from = from.Date;
      to = to.Date;

      int workingDaysCounter = 0;
      DateTime datePointer = from;

      while (true) {

        if (datePointer == to) {
          return workingDaysCounter;
        } else {
          datePointer = datePointer.AddDays(1);
        }

        if (IsWorkingDate(datePointer)) {
          workingDaysCounter++;
        }

      }  // while
    }

    #endregion Methods

    #region Helpers

    private bool IncludedInANonWorkingDaysPeriod(DateTime date) {
      foreach (var period in NonWorkingDaysPeriods) {
        if (period.Includes(date)) {
          return true;
        }
      }
      return false;
    }


    private bool IsNonWorkingDateException(DateTime date) {
      return NonWorkingDaysExceptions.Contains(date.Date);
    }


    private void LoadJsonData(JsonObject json) {

      Holidays = json.GetFixedList<DateTime>("holidays", false);

      NonWorkingDaysPeriods = json.GetFixedList<TimePeriod>("nonWorkingPeriods", false);
      NonWorkingDaysExceptions = json.GetFixedList<DateTime>("nonWorkingExceptions", false);

      if (json.HasValue("weekendDays")) {
        WeekendDays = json.GetFixedList<DayOfWeek>("weekendDays");
      } else {
        WeekendDays = new DayOfWeek[2] { DayOfWeek.Saturday, DayOfWeek.Sunday }.ToFixedList();
      }
    }

    #endregion Helpers

  } // class EmpiriaCalendar

} // namespace Empiria.Time
