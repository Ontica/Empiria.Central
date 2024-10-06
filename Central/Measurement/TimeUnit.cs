/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Measurement                                Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Enumeration Type                        *
*  Type     : TimeUnit                                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes a time unit.                                                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Measurement {

  /// <summary>Describes a time unit.</summary>
  public enum TimeUnit {

    Seconds = 'S',

    Minutes = 'M',

    Hours = 'H',

    CalendarDays = 'C',

    BusinessDays = 'B',

    Weeks = 'W',

    Months = 'M',

    Years = 'Y',

    Unknown = 'U',

  }  // enum TimeUnit

}  // namespace Empiria.Measurement
