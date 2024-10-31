﻿/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Services.Tests.dll         Pattern   : Services tests                          *
*  Type     : DocumentLinkServicesTests                  License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for document link services.                                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Documents;
using Empiria.Documents.Services;
using Empiria.Documents.Services.Adapters;

namespace Empiria.Tests.Documents.Services {

  /// <summary>Test cases for document link services.</summary>
  public class DocumentLinkServicesTests {

    #region Initialization

    private readonly DocumentLinkServices _services;

    public DocumentLinkServicesTests() {
      TestsCommonMethods.Authenticate();

      _services = DocumentLinkServices.ServiceInteractor();
    }

    ~DocumentLinkServicesTests() {
      _services.Dispose();
    }

    #endregion Initialization

    #region Facts


    [Fact]
    public void Should_Create_A_Document_Link_Complete () {

      var fields = new DocumentLinkFields {
        LinkedEntityRole = "Responsable"
      };

      DocumentLinkDto sut = _services.CreateLink(TestingConstants.DOCUMENT_LINK_TYPE,
                                                 TestingConstants.DOCUMENT,
                                                 TestingConstants.DOCUMENT_LINKED_ENTITY,
                                                 fields);
      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Create_A_Document_Link_Simple() {

      DocumentLinkDto sut = _services.CreateLink(TestingConstants.DOCUMENT,
                                                 TestingConstants.DOCUMENT_LINKED_ENTITY);

      Assert.NotNull(sut);
    }

    [Fact]
    public void Should_Delete_A_DocumentLink() {
      var sut = _services.DeleteLink(TestingConstants.DOCUMENT_LINK_UID);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_A_DocumentLink() {
      var sut = _services.GetLink(TestingConstants.DOCUMENT_LINK_UID);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_A_Document_Links() {
      var sut = _services.GetDocumentLinks(TestingConstants.DOCUMENT);

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Update_A_Document() {
      var fields = new DocumentLinkFields {
        UID = TestingConstants.DOCUMENT_LINK_UID,
        LinkedEntityRole = "Firmado por"
      };

      var sut = _services.UpdateLink(fields);

      Assert.NotNull(sut);
    }

    #endregion Facts

  }  // class DocumentLinkServicesTests

}  // namespace Empiria.Tests.Documents.Services