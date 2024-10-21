﻿/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Abstract Information Holder             *
*  Type     : SATDataItem                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Abstract type that holds a SAT Mexico data item used for electronic billing or budgeting.      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;
using Empiria.Json;
using Empiria.StateEnums;

namespace Empiria.Products.SATMexico {

  /// <summary>Abstract type that holds a SAT Mexico data item used for electronic billing or budgeting.</summary>
  abstract public class SATDataItem : BaseObject, INamedEntity {

    #region Constructors and parsers

    protected SATDataItem() {
      // Required by Empiria Framework.
    }

    #endregion Constructors and parsers

    #region Properties

    [DataField("SAT_DATA_ITEM_CODE")]
    public string Code {
      get; private set;
    }


    [DataField("SAT_DATA_ITEM_NAME")]
    public string Name {
      get; private set;
    }


    string INamedEntity.Name {
      get {
        return $"{Code} - {Name}";
      }
    }


    [DataField("SAT_DATA_ITEM_DESCRIPTION")]
    public string Description {
      get; private set;
    }


    [DataField("SAT_DATA_ITEM_FIELD_01")]
    protected internal string Field01 {
      get; set;
    }


    [DataField("SAT_DATA_ITEM_FIELD_02")]
    protected internal string Field02 {
      get; set;
    }


    [DataField("SAT_DATA_ITEM_FIELD_03")]
    protected internal string Field03 {
      get; set;
    }


    [DataField("SAT_DATA_ITEM_FIELD_04")]
    protected internal string Field04 {
      get; set;
    }


    [DataField("SAT_DATA_ITEM_EXT_DATA")]
    protected internal JsonObject ExtData {
      get; private set;
    }


    [DataField("SAT_DATA_ITEM_START_DATE")]
    public DateTime StartDate {
      get; private set;
    }


    [DataField("SAT_DATA_ITEM_END_DATE")]
    public DateTime EndDate {
      get; private set;
    }


    [DataField("SAT_DATA_ITEM_STATUS", Default = EntityStatus.Active)]
    public EntityStatus Status {
      get; private set;
    }


    public virtual string Keywords {
      get {
        return EmpiriaString.BuildKeywords(Code, Name, Field01, Field02, Field03, Field04, Description);
      }
    }

    #endregion Properties

  } // class SATDataItem

} // namespace Empiria.Products
