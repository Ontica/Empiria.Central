﻿/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Empiria Central Framework                    Component : Test cases                            *
*  Assembly : Empiria.Central.Tests.dll                    Pattern   : Testing constants                     *
*  Type     : TestingConstants                             License   : Please read LICENSE.txt file          *
*                                                                                                            *
*  Summary  : Provides testing constants for Empiria Central Framework types and components.                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/


using System.IO;

using Empiria.Documents;
using Empiria.Parties;
using Empiria.Products;
using Empiria.Storage;

namespace Empiria.Tests {

  /// <summary>Provides testing constants for Empiria Central Framework types and components.</summary>
  static public class TestingConstants {

    static internal readonly string DOCUMENT_CATEGORY_UID = "0e29ef34-ebbc-47e1-8cee-f5175bcc38d4";

    static internal readonly Product DOCUMENT_ENTITY = Product.Parse(1);

    static internal readonly string DOCUMENT_UID = "01770b13-8c25-4353-add9-79b6cc7287bd";

    static internal readonly string DOCUMENT_LINK_TYPE_UID = "baa1aef6-f7a7-4c13-b8a3-93dc48af5e50";

    static internal readonly string DOCUMENT_LINK_UID = "ed3b5dd9-3e0d-472e-be64-f453792365ea";

    static internal readonly Document DOCUMENT = Document.Parse(1);

    static internal Person PERSON => Person.Parse(2000);

    static internal readonly string PRODUCT_CATEGORY_UID = "e5a8e60e-2a07-4817-b2f4-9b42083d5986";

    static internal readonly string PRODUCT_TYPE_UID = "ObjectTypeInfo.Product.Good.Durable";

    static internal readonly string PRODUCT_UID = "39bf118b-aaf9-46f3-ae69-e871ac9d9c50";

    static internal readonly string PROJECT_ID = "8965587c-982e-49aa-bc81-0339e5d66578";

    static internal readonly string PROJECT_TYPE_ID = "fbc0f83d-ab5e-4596-a6dc-9d94ccdacf9a";

    static internal InputFile INPUT_FILE => new InputFile(new FileInfo(INPUT_FILE_NAME));

    static internal readonly string INPUT_FILE_NAME = @"D:\\Desktop\\AnalysisPatterns.Fowler.pdf";

  }  // class TestingConstants

}  // namespace Empiria.Tests.Central
