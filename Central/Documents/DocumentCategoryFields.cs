/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Input Fields DTO                        *
*  Type     : DocumentCategoryFields                     License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input fields DTO used to create and update DocumentCategory instances.                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Documents {

  /// <summary>Input fields DTO used to create and update DocumentCategory instances.</summary>
  public class DocumentCategoryFields : NamedEntityFields {

    public string DocumentTypeUID {
      get; set;
    } = string.Empty;


    public string Description {
      get; set;
    } = string.Empty;


    public bool? IsAssignable {
      get; set;
    }

    public string ParentCategoryUID {
      get; set;
    } = string.Empty;

  }  // class DocumentCategoryFields



  /// <summary>Extension methods for DocumentCategoryFields.</summary>
  public static class DocumentCategoryFieldsExtensions {

    static internal void EnsureValid(this DocumentCategoryFields fields) {

      fields.Name = EmpiriaString.Clean(fields.Name);
      fields.Description = EmpiriaString.Clean(fields.Description);

      if (fields.DocumentTypeUID.Length != 0) {
        _ = DocumentType.Parse(fields.DocumentTypeUID);
      }

      if (fields.ParentCategoryUID.Length != 0) {
        _ = DocumentCategory.Parse(fields.ParentCategoryUID);
      }

    }

  }  // class DocumentCategoryFieldsExtensions

}  // namespace Empiria.Products
