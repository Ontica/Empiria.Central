/* Empiria Financial *****************************************************************************************
*                                                                                                            *
*  Module   : Documents                                     Component : Interface adapters                   *
*  Assembly : Empiria.Central.dll                           Pattern   : Data Transfer Object                 *
*  Type     : ReportTypeDto                                 License   : Please read LICENSE.txt file         *
*                                                                                                            *
*  Summary  : DTO used to describe report types.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/
namespace Empiria.Documents {

  /// <summary>DTO used to describe report types.</summary>
  public class ReportTypeDto {

    public string UID {
      get; internal set;
    } = string.Empty;


    public string Name {
      get; internal set;
    } = string.Empty;


    public string Group {
      get; internal set;
    } = string.Empty;


    public string Controller {
      get; internal set;
    }


  } // class ReportTypeDto

} // namespace Empiria.Documents
