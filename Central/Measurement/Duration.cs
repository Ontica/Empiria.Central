/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Measurement                                Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Value Type                              *
*  Type     : Duration                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes a time duration (e.g, 10 business days, 8 hours, 3 months, etc).                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

namespace Empiria.Measurement {

  /// <summary>Describes a time duration (e.g, 10 business days, 8 hours, 3 months, etc).</summary>
  public class Duration {

    #region Fields

    private readonly string _string_value;

    #endregion Fields

    #region Constructors and parsers

    private Duration(string value) {
      _string_value = EmpiriaString.TrimAll(value);

      Load();
    }


    public Duration(int value, TimeUnit type) {
      _string_value = GetStringValue(value, type);

      Load();
    }


    static public Duration Parse(string value) {
      if (string.IsNullOrWhiteSpace(value)) {
        return Empty;
      }

      return new Duration(value);
    }


    static public Duration Empty {
      get {
        var emptyDuration = new Duration(string.Empty);

        emptyDuration.IsEmptyInstance = true;

        return emptyDuration;
      }
    }


    #endregion Constructors and parsers

    #region Properties

    public bool IsEmptyInstance {
      get;
      private set;
    } = false;


    public TimeUnit DurationType {
      get;
      private set;
    } = TimeUnit.Unknown;


    public int Value {
      get;
      private set;
    } = 0;


    #endregion Properties

    #region Methods

    public decimal ToDays() {
      switch (DurationType) {
        case TimeUnit.Hours:
          return Value / 24.0m;

        case TimeUnit.CalendarDays:
          return Value;

        case TimeUnit.BusinessDays:
          return Value;

        case TimeUnit.Months:
          return Value * 30;

        case TimeUnit.Years:
          return Value * 365;

        case TimeUnit.Unknown:
          return 0;

        default:
          throw Assertion.EnsureNoReachThisCode("Unrecognized");
      }
    }


    public object ToJson() {
      return new {
        value = Value,
        type = DurationType.ToString()
      };
    }


    public override string ToString() {
      return _string_value;
    }

    #endregion Methods

    #region Helpers

    private TimeUnit GetDurationType(string durationType) {
      durationType = durationType.ToLowerInvariant();

      if (EmpiriaString.IsInList(durationType, "hours", "hour")) {
        return TimeUnit.Hours;

      } else if (EmpiriaString.IsInList(durationType,
                                  "days", "day", "calendarday", "calendardays",
                                  "calendar-day", "calendar-days")) {
        return TimeUnit.CalendarDays;

      } else if (EmpiriaString.IsInList(durationType,
                                  "businessday", "businessdays",
                                  "workday", "workdays", "workingday", "workingdays",
                                  "business-days", "business-day",
                                  "work-days", "work-day",
                                  "working-days", "working-day")) {
        return TimeUnit.BusinessDays;

      } else if (EmpiriaString.IsInList(durationType, "months", "month")) {
        return TimeUnit.Months;

      } else if (EmpiriaString.IsInList("years", "year")) {
        return TimeUnit.Years;

      } else if (durationType == "unknown") {
        return TimeUnit.Unknown;

      } else {
        throw Assertion.EnsureNoReachThisCode($"Unrecognized duration type '{durationType}'.");

      }
    }


    private string GetStringValue(int value, TimeUnit type) {
      switch (type) {
        case TimeUnit.Hours:
          return value + " horas";

        case TimeUnit.CalendarDays:
          return value + " días";

        case TimeUnit.BusinessDays:
          return value + " días hábiles";

        case TimeUnit.Months:
          return value + " meses";

        case TimeUnit.Years:
          return value + " años";

        case TimeUnit.Unknown:
          return value + " ?";

        default:
          throw Assertion.EnsureNoReachThisCode("Unrecognized");
      }
    }


    private void Load() {
      string[] parts = _string_value.Split(' ');

      if (parts.Length == 2) {
        Value = int.Parse(parts[0]);
        DurationType = GetDurationType(parts[1]);
      }
    }

    #endregion Helpers

  } // class Duration

} // namespace Empiria.Measurement
