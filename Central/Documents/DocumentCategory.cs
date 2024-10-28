/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : DocumentCategory                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a document category which holds documents of the same kind or document type.        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.StateEnums;

namespace Empiria.Documents {

  /// <summary>Represents a document category which holds documents of the same kind or document type.</summary>
  public class DocumentCategory : GeneralObject {

    #region Constructors and parsers

    private DocumentCategory() {
      // Required by Empiria Framework
    }

    internal DocumentCategory(DocumentType documentType, string name) {
      Assertion.Require(documentType, nameof(documentType));

      name = EmpiriaString.Clean(name);

      Assertion.Require(name, nameof(name));

      DocumentType = documentType;
      Name = name;
    }

    static public DocumentCategory Parse(int id) => ParseId<DocumentCategory>(id);

    static public DocumentCategory Parse(string uid) => ParseKey<DocumentCategory>(uid);

    static public FixedList<DocumentCategory> GetList() {
      return BaseObject.GetList<DocumentCategory>()
                       .ToFixedList();
    }

    static public DocumentCategory Empty => ParseEmpty<DocumentCategory>();

    #endregion Constructors and parsers

    #region Properties

    public DocumentType DocumentType {
      get {
        return base.ExtendedDataField.Get("documentTypeId", DocumentType.Empty);
      }
      private set {
        base.ExtendedDataField.SetIf("documentTypeId", value.Id, value.Id != -1);
      }
    }


    public string Description {
      get {
        return base.ExtendedDataField.Get("description", string.Empty);
      }
      private set {
        base.ExtendedDataField.SetIfValue("description", EmpiriaString.TrimAll(value));
      }
    }


    public bool IsAssignable {
      get {
        return base.ExtendedDataField.Get("isAssignable", IsEmptyInstance ? false : true);
      }
      private set {
        base.ExtendedDataField.SetIf("isAssignable", value, value == false);
      }
    }


    public DocumentCategory Parent {
      get {
        return base.ExtendedDataField.Get("parentCategoryId", DocumentCategory.Empty);
      }
      private set {
        base.ExtendedDataField.SetIf("parentCategoryId", value.Id, value.Id != -1);
      }
    }


    public override string Keywords {
      get {
        if (IsEmptyInstance) {
          return string.Empty;
        }
        return EmpiriaString.BuildKeywords(Name, DocumentType.DisplayName, Parent.Keywords);
      }
    }

    #endregion Properties

    #region Methods

    internal void Delete() {
      base.Status = EntityStatus.Deleted;
    }


    internal void Update(DocumentCategoryFields fields) {
      Assertion.Require(fields, nameof(fields));

      fields.EnsureValid();

      Name = PatchField(fields.Name, Name);
      Description = PatchField(fields.Description, Description);
      Parent = PatchField(fields.ParentCategoryUID, Parent);
      IsAssignable = PatchField(fields.IsAssignable, IsAssignable);
    }

    #endregion Methods

  } // class DocumentCategory

} // namespace Empiria.Documents
