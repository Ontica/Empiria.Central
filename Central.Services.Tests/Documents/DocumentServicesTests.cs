/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Services.Tests.dll         Pattern   : Services tests                          *
*  Type     : DocumentServicesTests                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Test cases for document services.                                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Documents;
using Empiria.Documents.Services;
using Empiria.Documents.Services.Adapters;

namespace Empiria.Tests.Documents.Services {

  /// <summary>Test cases for document services.</summary>
  public class DocumentServicesTests {

    #region Initialization

    private readonly DocumentServices _services;

    public DocumentServicesTests() {
      TestsCommonMethods.Authenticate();

      _services = DocumentServices.ServiceInteractor();
    }

    ~DocumentServicesTests() {
      _services.Dispose();
    }

    #endregion Initialization

    #region Facts

    [Fact]
    public void Should_Create_A_Document() {

      var fields = new DocumentFields {
        DocumentCategoryUID = TestingConstants.DOCUMENT_CATEGORY_UID,
        Name = "Servicios de desarrollo de software"
      };

      DocumentDto sut = _services.CreateDocument(TestingConstants.DOCUMENT_ENTITY, fields);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Delete_A_Document() {
      var sut = _services.DeleteDocument(TestingConstants.DOCUMENT_UID);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_A_Document() {
      var sut = _services.GetDocument(TestingConstants.DOCUMENT_UID);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_Documents_For_An_Entity() {
      var sut = _services.GetDocumentsForEntity(TestingConstants.DOCUMENT_ENTITY);

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Update_A_Document() {
      var fields = new DocumentFields {
        UID = TestingConstants.DOCUMENT_UID,
        Name = "Carta compromiso de entrega del proveedor",
        Description = "Entregar antes del 23 de octubre de 2024"
      };

      var sut = _services.UpdateDocument(fields);

      Assert.NotNull(sut);
    }

    #endregion Facts

  }  // class DocumentServicesTests

}  // namespace Empiria.Tests.Documents.Services
