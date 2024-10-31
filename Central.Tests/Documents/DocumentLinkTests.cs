/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : DocumentLinkTests                          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for DocumentLink instances.                                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Xunit;

using Empiria.StateEnums;

using Empiria.Documents;

namespace Empiria.Tests.Documents {

  /// <summary>Unit tests for DocumentLink instances.</summary>
  public class DocumentLinkTests {

    [Fact]
    public void Should_Create_A_DocumentLink() {
      var linkType = DocumentLinkType.Parse(TestingConstants.DOCUMENT_LINK_TYPE_UID);

      var sut = new DocumentLink(linkType, TestingConstants.DOCUMENT, TestingConstants.PERSON);

      Assert.Equal(linkType, sut.DocumentLinkType);
      Assert.Equal(TestingConstants.DOCUMENT, sut.Document);
      Assert.Equal(TestingConstants.PERSON, sut.GetLinkedEntity());
    }


    [Fact]
    public void Should_Delete_A_DocumentLink() {
      var sut = DocumentLink.Parse(TestingConstants.DOCUMENT_LINK_UID);

      sut.Delete();

      Assert.Equal(EntityStatus.Deleted, sut.Status);
    }


    [Fact]
    public void Should_Get_All_Document_Links() {
      var sut = BaseObject.GetFullList<DocumentLink>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_All_Documents_Links_For_A_Document() {
      var sut = DocumentLink.GetListFor(TestingConstants.DOCUMENT);

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }


    [Fact]
    public void Should_Get_Empty_DocumentLink() {
      var sut = DocumentLink.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.NotNull(sut.DocumentLinkType);
      Assert.NotNull(sut.Document);
      Assert.NotEmpty(sut.Keywords);
      Assert.NotNull(sut.ExtensionData);
      Assert.NotNull(sut.Identificators);
      Assert.NotNull(sut.Tags);
      Assert.NotNull(sut.PostedBy);
      Assert.NotNull(sut.LinkedEntityRole);
      Assert.NotNull(sut.GetLinkedEntity());
    }


    [Fact]
    public void Should_Parse_All_Documents_Links() {
      var links = BaseObject.GetFullList<DocumentLink>("DOCUMENT_LINK_ID <> -1");

      foreach (var sut in links) {
        Assert.NotNull(sut.DocumentLinkType);
        Assert.NotNull(sut.Document);
        Assert.NotEmpty(sut.Keywords);
        Assert.NotNull(sut.ExtensionData);
        Assert.NotNull(sut.Identificators);
        Assert.NotNull(sut.Tags);
        Assert.NotNull(sut.PostedBy);
        Assert.NotNull(sut.LinkedEntityRole);
        Assert.NotNull(sut.GetLinkedEntity());
      }
    }


    [Fact]
    public void Should_Update_A_DocumentLink() {
      var sut = DocumentLink.Parse(TestingConstants.DOCUMENT_LINK_UID);

      var fields = new DocumentLinkFields {
        LinkedEntityRole = " Autorizado por ",
      };

      sut.Update(fields);

      Assert.Equal(EmpiriaString.Clean(fields.LinkedEntityRole), sut.LinkedEntityRole);
    }

  }  // class DocumentLinkTests

}  // namespace Empiria.Tests.Documents
