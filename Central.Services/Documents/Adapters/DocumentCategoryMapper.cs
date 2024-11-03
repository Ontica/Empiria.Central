/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.Services.dll               Pattern   : Mapper                                  *
*  Type     : DocumentCategoryMapper                     License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides mapping services for DocumentCategory instances.                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Documents.Services.Adapters {

  /// <summary>Provides mapping services for DocumentCategory instances.</summary>
  static internal class DocumentCategoryMapper {

    static internal FixedList<DocumentCategoryDto> Map(FixedList<DocumentCategory> categories) {
      return categories.Select(x => Map(x))
                      .ToFixedList();
    }


    static internal DocumentCategoryDto Map(DocumentCategory category) {
      return new DocumentCategoryDto {
        UID = category.UID,
        Name = category.Name,
        Products = Map(category.GetProducts())
      };
    }

    static private FixedList<DocumentProductDto> Map(FixedList<DocumentProduct> products) {
      return products.Select(x => Map(x))
                     .ToFixedList();
    }

    static private DocumentProductDto Map(DocumentProduct product) {
      return new DocumentProductDto {
        UID = product.UID,
        Name = product.Name,
        FileType = product.FileType,
        AppplicationContentType = product.ApplicationContentType
      };
    }
  }  // class DocumentCategoryMapper

} // namespace Empiria.Documents.Services.Adapters
