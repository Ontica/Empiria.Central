/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : FileLocation                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Holds information about a physical file directory or a documents web site.                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Documents {

  /// <summary>Holds information about a physical file directory or a documents web site.</summary>
  public class FileLocation : GeneralObject {

    static public FileLocation Parse(int id) => ParseId<FileLocation>(id);

    static public FileLocation Parse(string uid) => ParseKey<FileLocation>(uid);

    static public FileLocation Empty => ParseEmpty<FileLocation>();

  }  // class FileLocation

}  // namespace Empiria.Documents
