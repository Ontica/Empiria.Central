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

namespace Empiria.Tests.Documents.Services {

  /// <summary>Test cases for document services.</summary>
  public class DocumentServicesTests {

    #region Facts

    [Fact]
    public void Should_Create_A_Document() {

      var fields = new DocumentFields {
        DocumentProductUID = TestingConstants.DOCUMENT_PRODUCT_UID,
        Name = "Servicios de desarrollo de software"
      };

      DocumentDto sut = DocumentServices.StoreDocument(TestingConstants.INPUT_FILE,
                                                       TestingConstants.DOCUMENT_ENTITY,
                                                       fields);

      Assert.NotNull(sut);
    }


    //[Fact]
    //public void Should_Remove_A_Document() {
    //  var sut = DocumentServices.RemoveDocument(TestingConstants.DOCUMENT_UID);

    //  Assert.NotNull(sut);
    //}


    [Fact]
    public void Should_Get_A_Document() {
      var sut = DocumentServices.GetDocument(TestingConstants.DOCUMENT_UID);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_Entity_Documents() {
      var sut = DocumentServices.GetAllEntityDocuments(TestingConstants.DOCUMENT_ENTITY);

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    //[Fact]
    //public void Should_Update_A_Document() {
    //  var fields = new DocumentFields {
    //    UID = TestingConstants.DOCUMENT_UID,
    //    Name = "Carta compromiso de entrega del proveedor",
    //    Description = "Entregar antes del 23 de octubre de 2024"
    //  };

    //  var sut = DocumentServices.UpdateDocument(fields);

    //  Assert.NotNull(sut);
    //}

    #endregion Facts

  }  // class DocumentServicesTests

}  // namespace Empiria.Tests.Documents.Services
