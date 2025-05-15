/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Partitioned type                        *
*  Type     : DocumentProduct                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Partitioned type that represents a document product.                                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Ontology;

using Empiria.Storage;

using Empiria.Products;

namespace Empiria.Documents {

  /// <summary>Partitioned type that represents a good or a service.</summary>
  [PartitionedType(typeof(DocumentType))]
  internal class DocumentProduct : Product {

    #region Constructors and parsers

    protected DocumentProduct(DocumentType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    internal protected DocumentProduct(DocumentCategory documentCategory,
                                       string name) : base(documentCategory, name) {
      // no-op
    }

    static public new DocumentProduct Parse(int id) => ParseId<DocumentProduct>(id);

    static public new DocumentProduct Parse(string uid) => ParseKey<DocumentProduct>(uid);

    static public new DocumentProduct Empty => ParseEmpty<DocumentProduct>();

    #endregion Constructors and parsers

    #region Properties

    public new DocumentType ProductType {
      get {
        return (DocumentType) base.GetEmpiriaType();
      }
    }


    public new DocumentCategory ProductCategory {
      get {
        return (DocumentCategory) base.ProductCategory;
      }
    }


    public FileType FileType {
      get {
        return base.ExtensionData.Get("fileType", FileType.Unknown);
      }
      private set {
        base.ExtensionData.SetIf("fileType", value, value != FileType.Unknown);
      }
    }


    public string ApplicationContentType {
      get {
        return base.ExtensionData.Get("applicationContentType", string.Empty);
      }
      private set {
        base.ExtensionData.SetIfValue("applicationContentType", value);
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(base.Keywords);
      }
    }

    #endregion Properties

  } // class DocumentProduct

}  // namespace Empiria.Products
