/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : DocumentCategoryTests                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for DocumentCategory instances.                                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Documents;

namespace Empiria.Tests.Documents {

  /// <summary>Unit tests for DocumentCategory instances.</summary>
  public class DocumentCategoryTests {

    [Fact]
    public void Should_Get_All_Document_Categories() {
      var sut = BaseObject.GetFullList<DocumentCategory>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_DocumentCategory() {
      var sut = DocumentCategory.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.NotEmpty(sut.Name);
    }


    [Fact]
    public void Should_Parse_All_Document_Categories() {
      var categories = BaseObject.GetFullList<DocumentCategory>();

      foreach (var sut in categories) {
        Assert.NotEmpty(sut.Name);
        Assert.NotNull(sut.ProductType);
        Assert.NotNull(sut.FileLocation);
        Assert.NotNull(sut.Parent);
        Assert.NotEmpty(sut.Keywords);
        Assert.NotNull(sut.Description);
      }
    }

  }  // class DocumentCategoryTests

}  // namespace Empiria.Tests.Documents
