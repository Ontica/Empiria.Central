/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : DocumentLinkTypeTests                      License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for DocumentLinkType instances.                                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.Documents;

namespace Empiria.Tests.Documents {

  /// <summary>Unit tests for DocumentLinkType instances.</summary>
  public class DocumentLinkTypeTests {

    [Fact]
    public void Should_Get_All_Document_Links_Types() {
      var sut = BaseObject.GetFullList<DocumentLinkType>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_DocumentLinkType() {
      var sut = DocumentLinkType.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
    }


    [Fact]
    public void Should_Parse_All_Documents_Links_TYpes() {
      var links = BaseObject.GetFullList<DocumentLinkType>();

      foreach (var sut in links) {
        Assert.NotNull(sut.Name);
        Assert.NotNull(sut.LinkedObjectType);
      }
    }

  }  // class DocumentLinkTypeTests

}  // namespace Empiria.Tests.Documents
