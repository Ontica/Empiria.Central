/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.Core.dll                   Pattern   : Input fields DTO                        *
*  Type     : DocumentLinkFields                         License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input fields DTO used to create and update DocumentLink instances.                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Documents {

  /// <summary>Input fields DTO used to create and update DocumentLink instances.</summary>
  public class DocumentLinkFields : NamedEntityFields {

    public string LinkedEntityRole {
      get; set;
    } = string.Empty;

  }  // class DocumentLinkFields



  /// <summary>Extension methods for DocumentLinkFields.</summary>
  static public class DocumentLinkFieldsExtensions {

    static public void EnsureValid(this DocumentLinkFields fields) {

    }

  }  // class DocumentLinkFieldsExtensions

}  // namespace Empiria.Documents
