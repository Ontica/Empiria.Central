/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Empiria Central Framework                    Component : Test cases                            *
*  Assembly : Empiria.Central.Services.Tests.dll           Pattern   : Testing constants                     *
*  Type     : TestingConstants                             License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Provides testing constants for Empiria Central Services.                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

using Empiria.Documents;
using Empiria.Storage;
using System.IO;

namespace Empiria.Tests {

  /// <summary>Provides testing constants for Empiria Central Services.</summary>
  static public class TestingConstants {

    static internal readonly string DOCUMENT_UID = "01770b13-8c25-4353-add9-79b6cc7287bd";

    static internal readonly string DOCUMENT_CATEGORY_UID = "0e29ef34-ebbc-47e1-8cee-f5175bcc38d4";

    static internal readonly Person DOCUMENT_ENTITY = Person.Parse(2000);

    static internal readonly Document DOCUMENT = Document.Parse(1);

    static internal readonly DocumentLinkType DOCUMENT_LINK_TYPE = DocumentLinkType.Parse("baa1aef6-f7a7-4c13-b8a3-93dc48af5e50");

    static internal readonly BaseObject DOCUMENT_LINKED_ENTITY = DOCUMENT_ENTITY;

    static internal readonly string DOCUMENT_LINK_UID = "ed3b5dd9-3e0d-472e-be64-f453792365ea";

    static internal InputFile INPUT_FILE => new InputFile(new FileInfo(INPUT_FILE_NAME));

    public static string DOCUMENT_PRODUCT_UID {
      get;
      internal set;
    }

    static internal readonly string INPUT_FILE_NAME = @"D:\\Desktop\\AnalysisPatterns.Fowler.pdf";

    static internal readonly string PRODUCT_CATEGORY_UID = "e5a8e60e-2a07-4817-b2f4-9b42083d5986";

    static internal readonly string PRODUCT_UID = "39bf118b-aaf9-46f3-ae69-e871ac9d9c50";

  }  // class TestingConstants

}  // namespace Empiria.Tests
