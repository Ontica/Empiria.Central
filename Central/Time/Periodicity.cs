/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Time                                       Component : Domain Types                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : Periodicity                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a periodicity.                                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Time {

  /// <summary>Represents a periodicity.</summary>
  public class Periodicity : GeneralObject {

    #region Constructors and parsers

    static public Periodicity Parse(int id) => ParseId<Periodicity>(id);

    static public Periodicity Parse(string uid) => ParseKey<Periodicity>(uid);

    static public FixedList<Periodicity> GetList() => GetList<Periodicity>().ToFixedList();

    static public Periodicity Empty => ParseEmpty<Periodicity>();

    #endregion Constructors and parsers

  }  // class Periodicity

}  // namespace Empiria.Time
