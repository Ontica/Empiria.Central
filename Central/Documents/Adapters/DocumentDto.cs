/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Output DTO                              *
*  Type     : DocumentDto                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Output DTO for Document instances.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Storage;

namespace Empiria.Documents {

  /// <summary>Output DTO for Document instances.</summary>
  public class DocumentDto : INamedEntity {

    public string UID {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public string DocumentNo {
      get; internal set;
    }

    public DateTime DocumentDate {
      get; internal set;
    }

    public NamedEntityDto DocumentProduct {
      get; internal set;
    }

    public NamedEntityDto DocumentCategory {
      get; internal set;
    }

    public string Description {
      get; internal set;
    }

    public FixedList<string> Tags {
      get; internal set;
    }

    public DateTime PostingTime {
      get; internal set;
    }

    public NamedEntityDto PostedBy {
      get;
      internal set;
    }

    public DateTime LastUpdateTime {
      get; internal set;
    }

    public NamedEntityDto Status {
      get; internal set;
    }

    public FileDto File {
      get; internal set;
    }

    public string FullLocalName {
      get; internal set;
    }

    public string ApplicationContentType {
      get; internal set;
    }

  }  // class DocumentDto


  /// <summary>Output DTO for Document instances to be used in lists.</summary>
  public class DocumentDescriptorDto : INamedEntity {

    public string UID {
      get; internal set;
    }

    public string Name {
      get; internal set;
    }

    public string Description {
      get; internal set;
    }

    public DateTime PostingTime {
      get; internal set;
    }

    public string PostedByName {
      get; internal set;
    }

    public string StatusName {
      get; internal set;
    }

    public FileDto FileDto {
      get; internal set;
    }

  }  // class DocumentDescriptorDto

}  // namespace Empiria.DocumentDto
