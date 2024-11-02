/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Output DTO                              *
*  Type     : DocumentCategoryDto                        License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO with a DocumentCategory data.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Storage;

namespace Empiria.Documents.Services.Adapters {

  /// <summary>Output DTO with a DocumentCategory data.</summary>
  public class DocumentCategoryDto : NamedEntityFields {

    public FixedList<DocumentProductDto> Products {
      get;
      internal set;
    }

  }  // class DocumentCategoryDto


  public class DocumentProductDto : NamedEntityFields {

    public FileType FileType {
      get; internal set;
    }
    public string AppplicationContentType {
      get;
      internal set;
    }
  }

}  // namespace Empiria.Documents.Services.Adapters

