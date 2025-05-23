﻿/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Services Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Services interactor class               *
*  Type     : DocumentCategoryServices                   License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Services for DocumentCategory instances.                                                       *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

namespace Empiria.Documents {

  /// <summary>Services for DocumentCategory instances.</summary>
  public class DocumentCategoryServices : Service {

    #region Constructors and parsers

    protected DocumentCategoryServices() {
      // no-op
    }

    static public DocumentCategoryServices ServiceInteractor() {
      return Service.CreateInstance<DocumentCategoryServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public FixedList<DocumentCategoryDto> GetDocumentCategories() {

      var categories = BaseObject.GetFullList<DocumentCategory>()
                                 .FindAll(x => x.Status != StateEnums.EntityStatus.Deleted)
                                 .Sort((x, y) => x.Name.CompareTo(y.Name));

      return DocumentCategoryMapper.Map(categories);
    }

    #endregion Services

  }  // class DocumentCategoryServices

}  // namespace Empiria.Documents.Services
