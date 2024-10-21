/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : SATUnidadMedida                            License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Unidad de medida de acuerdo al catálogo del SAT México para facturación electrónica.           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products.SATMexico {

  /// <summary>Unidad de medida de acuerdo al catálogo del SAT México para facturación electrónica.</summary>
  public class SATUnidadMedida : SATDataItem {

    #region Constructors and parsers

    static public SATUnidadMedida Parse(int id) => ParseId<SATUnidadMedida>(id);

    static public SATUnidadMedida Parse(string uid) => ParseKey<SATUnidadMedida>(uid);

    static public FixedList<SATUnidadMedida> GetList() {
      return BaseObject.GetList<SATUnidadMedida>()
                       .ToFixedList();
    }

    static public SATUnidadMedida Empty => ParseEmpty<SATUnidadMedida>();

    #endregion Constructors and parsers

  } // class SATUnidadMedida

} // namespace Empiria.Products.SATMexico
