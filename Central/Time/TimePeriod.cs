/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Time                                       Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Value Type                              *
*  Type     : TimePeriod                                 License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Holds information about a time period with start and end times.                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
using System;

using Empiria.Json;

namespace Empiria.Time {

  /// <summary>Holds information about a time period with start and end times.</summary>
  public struct TimePeriod {

    #region Constructors and parsers

    public TimePeriod(DateTime? startTime, DateTime? endTime)
                              : this(startTime ?? ExecutionServer.DateMinValue,
                                     endTime ?? ExecutionServer.DateMaxValue) {
    }


    public TimePeriod(DateTime startTime, DateTime endTime) {
      Assertion.Require(startTime <= endTime, "startTime should be before or equal to endTime.");

      this.StartTime = startTime;
      this.EndTime = endTime;
    }


    static public TimePeriod Parse(JsonObject json) {
      return new TimePeriod(json.Get<DateTime>("from"), json.Get<DateTime>("to"));
    }


    static public TimePeriod Default => new TimePeriod(ExecutionServer.DateMinValue,
                                                       ExecutionServer.DateMaxValue);

    #endregion Constructors and parsers

    #region Properties

    public DateTime StartTime {
      get;
    }


    public DateTime EndTime {
      get;
    }

    #endregion Properties

    #region Operators overloading

    static public bool operator ==(TimePeriod periodA, TimePeriod periodB) {
      return ((periodA.StartTime == periodB.StartTime) && (periodA.EndTime == periodB.EndTime));
    }


    static public bool operator !=(TimePeriod periodA, TimePeriod periodB) {
      return !(periodA == periodB);
    }

    #endregion Operators overloading

    #region Methods

    public override bool Equals(object o) {
      if (!(o is TimePeriod)) {
        return false;
      }

      TimePeriod temp = (TimePeriod) o;

      return ((this.StartTime == temp.StartTime) && (this.EndTime == temp.EndTime));
    }


    public override int GetHashCode() {
      return (this.ToString().GetHashCode());
    }


    public bool Includes(DateTime date) {
      if ((this.EndTime.TimeOfDay.Hours == 0) &&
          (this.StartTime <= date && date < this.EndTime.AddSeconds(86400))) {
        return true;
      }

      return (this.StartTime <= date && date <= this.EndTime);
    }


    public override string ToString() {
      return this.StartTime.ToString("yyyymmdd") + "." + this.EndTime.ToString("yyyymmdd");
    }

    #endregion Methods

  } // struct TimePeriod

} // namespace Empiria.Time
