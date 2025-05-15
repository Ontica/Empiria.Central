/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : DocumentCategory                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a document category which holds documents of the same kind or document type.        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Products;
using Empiria.Storage;

namespace Empiria.Documents {

  /// <summary>Represents a document category which holds documents of the same kind or document type.</summary>
  internal class DocumentCategory : ProductCategory {

    #region Constructors and parsers

    protected DocumentCategory() {
      // Required by Empiria Framework
    }

    internal DocumentCategory(DocumentType documentType, string name) {
      Assertion.Require(documentType, nameof(documentType));

      name = EmpiriaString.Clean(name);

      Assertion.Require(name, nameof(name));

      ProductType = documentType;
      Name = name;
    }

    static public new DocumentCategory Parse(int id) => ParseId<DocumentCategory>(id);

    static public new DocumentCategory Parse(string uid) => ParseKey<DocumentCategory>(uid);

    static public new FixedList<DocumentCategory> GetList() {
      return BaseObject.GetList<DocumentCategory>()
                       .ToFixedList();
    }

    static public new DocumentCategory Empty => ParseEmpty<DocumentCategory>();

    #endregion Constructors and parsers

    #region Properties

    public new DocumentType ProductType {
      get {
        return (DocumentType) base.ProductType;
      }
      private set {
        base.ProductType = value;
      }
    }


    public FileLocation FileLocation {
      get {
        return base.ExtData.Get<FileLocation>("fileLocationId");
      }
      private set {
        base.ExtData.Set("fileLocationId", value.Id);
      }
    }


    public new DocumentCategory Parent {
      get {
        return base.GetParent<DocumentCategory>();
      }
      private set {
        base.SetParent(value);
      }
    }


    public FixedList<DocumentProduct> GetProducts() {
      return ProductDataService.GetProductsInCategory<DocumentProduct>(this);
    }

    #endregion Properties

  } // class DocumentCategory

} // namespace Empiria.Documents
