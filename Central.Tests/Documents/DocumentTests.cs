/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Test cases                              *
*  Assembly : Empiria.Central.Tests.dll                  Pattern   : Unit tests                              *
*  Type     : DocumentTests                              License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unit tests for Document instances.                                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Xunit;

using Empiria.StateEnums;
using Empiria.Storage;

using Empiria.Documents;

namespace Empiria.Tests.Documents {

  /// <summary>Unit tests for Document instances.</summary>
  public class DocumentTests {


    [Fact]
    public void Should_Create_A_Document() {
      var documentCategory = DocumentCategory.Parse(TestingConstants.DOCUMENT_CATEGORY_UID);
      var name = "   A    new   document  ";

      var documentFile = FileData.Parse(TestingConstants.INPUT_FILE);

      var sut = new Document(documentCategory,
                             TestingConstants.DOCUMENT_ENTITY,
                             documentFile,
                             name);

      Assert.Equal(documentCategory, sut.DocumentCategory);
      Assert.Equal(documentCategory.ProductType, sut.DocumentType);
      Assert.Equal(EmpiriaString.Clean(name), sut.Name);
    }


    [Fact]
    public void Should_Delete_A_Document() {
      var sut = Document.Parse(TestingConstants.DOCUMENT_UID);

      sut.Delete();

      Assert.Equal(EntityStatus.Deleted, sut.Status);
      Assert.Equal(DateTime.Today.Date, sut.LastUpdateTime.Date);
    }


    [Fact]
    public void Should_Get_All_Documents() {
      var sut = BaseObject.GetFullList<Document>();

      Assert.NotNull(sut);
      Assert.NotEmpty(sut);
    }

    [Fact]
    public void Should_Get_Documents_For_An_Entity() {
      var sut = Document.GetListFor(TestingConstants.DOCUMENT_ENTITY);

      Assert.NotNull(sut);
    }


    [Fact]
    public void Should_Get_Empty_Document() {
      var sut = Document.Empty;

      Assert.Equal(-1, sut.Id);
      Assert.Equal("Empty", sut.UID);
      Assert.NotNull(sut.DocumentType);
      Assert.Equal(DocumentType.Empty, sut.DocumentType);
      Assert.NotNull(sut.DocumentCategory);
      Assert.Equal(DocumentCategory.Empty, sut.DocumentCategory);
      Assert.NotEmpty(sut.Name);
      Assert.NotNull(sut.DocumentNo);
      Assert.NotNull(sut.Description);
    }


    [Fact]
    public void Should_Parse_All_Documents() {
      var documents = BaseObject.GetFullList<Document>("DOCUMENT_ID <> -1");

      foreach (var sut in documents) {
        Assert.NotNull(sut.DocumentType);
        Assert.NotNull(sut.DocumentCategory);
        Assert.NotEmpty(sut.Name);
        Assert.NotNull(sut.DocumentNo);
        Assert.NotNull(sut.Description);
        Assert.NotNull(sut.DocumentProduct);
        Assert.NotNull(sut.SourceParty);
        Assert.NotNull(sut.TargetParty);
        Assert.NotNull(sut.GetBaseEntity());
      }
    }


    [Fact]
    public void Should_Update_A_Document() {
      var sut = Document.Parse(TestingConstants.DOCUMENT_UID);

      var fields = new DocumentFields {
        Name = " The  new    name ",
        Description = " This  is  the   new description ",
      };

      sut.Update(fields);

      Assert.Equal(EmpiriaString.Clean(fields.Name), sut.Name);
      Assert.Equal(EmpiriaString.Clean(fields.Description), sut.Description);
    }

  }  // class DocumentTests

}  // namespace Empiria.Tests.Documents
