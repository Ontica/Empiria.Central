/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Power type                              *
*  Type     : DocumentType                               License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Power type that describes a document.                                                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System.Linq;

using Empiria.Ontology;

namespace Empiria.Documents {

  /// <summary>Power type that describes a document.</summary>
  [Powertype(typeof(Document))]
  public class DocumentType : Powertype {

    #region Constructors and parsers

    private DocumentType() {
      // Empiria powertype types always have this constructor.
    }

    static public new DocumentType Parse(int typeId) => Parse<DocumentType>(typeId);

    static internal new DocumentType Parse(string typeName) => Parse<DocumentType>(typeName);

    static public DocumentType Empty => Parse("ObjectTypeInfo.Document");

    static internal FixedList<DocumentType> GetList() {
      return Empty.GetAllSubclasses()
                  .Select(x => (DocumentType) x)
                  .ToFixedList();
    }

    #endregion Constructors and parsers

  }  // class DocumentType

}  // namespace Empiria.Documents
