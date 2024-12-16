/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Data Access Layer                       *
*  Assembly : Empiria.Central.dll                        Pattern   : Data service                            *
*  Type     : SATDataItemDataService                     License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides data persistence services for SAT data items.                                         *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;

namespace Empiria.Products.SATMexico {

  /// <summary>Provides data persistence services for SAT data items.</summary>
  static internal class SATDataItemDataService {

    static internal void Write(SATDataItem o) {
      var op = DataOperation.Parse("write_OMS_SAT_Data_Item",
           o.Id, o.UID, o.GetEmpiriaType().Id, o.Code, o.Name, o.Description,
           o.Field01, o.Field02, o.Field03, o.Field04, o.Field05, o.Field06,
           o.ExtData.ToString(), o.Keywords, o.StartDate, o.EndDate, (char) o.Status);

      DataWriter.Execute(op);
    }

  }  // class SATDataItemDataService

}  // namespace Empiria.Products
