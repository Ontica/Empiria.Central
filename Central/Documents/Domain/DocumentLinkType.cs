/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.Core.dll                   Pattern   : Information Holder                      *
*  Type     : DocumentLinkType                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Describes a link between a document and other entities.                                        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Ontology;

namespace Empiria.Documents {

  /// <summary>Describes a link between a document and other entities.</summary>
  public class DocumentLinkType : GeneralObject {

    #region Constructors and parsers

    static public DocumentLinkType Parse(int id) => ParseId<DocumentLinkType>(id);

    static public DocumentLinkType Parse(string uid) => ParseKey<DocumentLinkType>(uid);

    static public FixedList<DocumentLinkType> GetList() {
      return BaseObject.GetList<DocumentLinkType>()
                       .ToFixedList();
    }

    static public DocumentLinkType Empty => ParseEmpty<DocumentLinkType>();

    #endregion Constructors and parsers

    #region Properties

    public ObjectTypeInfo LinkedObjectType {
      get {
        int id = ExtendedDataField.Get<int>("linkedObjectTypeId");

        return ObjectTypeInfo.Parse(id);
      }
    }

    #endregion Properties

    #region Methods

    internal BaseObject ParseLinkedObject(int linkedObjectId) {
      return LinkedObjectType.ParseObject(linkedObjectId);
    }


    internal BaseObject ParseLinkedObject(string linkedObjectUID) {
      Assertion.Require(linkedObjectUID, nameof(linkedObjectUID));

      return LinkedObjectType.ParseObject(linkedObjectUID);
    }

    #endregion Methods

  }  // class DocumentLinkType

}  // namespace Empiria.Documents
