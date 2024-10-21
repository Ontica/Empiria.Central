/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : SATProducto                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Producto o servicio de acuerdo al catálogo del SAT México para facturación electrónica.        *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products.SATMexico {

  /// <summary>Producto o servicio de acuerdo al catálogo del SAT México para facturación electrónica.</summary>
  public class SATProducto : SATDataItem {

    #region Constructors and parsers

    static public SATProducto Parse(int id) => ParseId<SATProducto>(id);

    static public SATProducto Parse(string uid) => ParseKey<SATProducto>(uid);

    static public FixedList<SATProducto> GetList() {
      return BaseObject.GetList<SATProducto>()
                       .ToFixedList();
    }

    static public SATProducto Empty => ParseEmpty<SATProducto>();

    #endregion Constructors and parsers

  } // class SATProducto

} // namespace Empiria.Products.SATMexico
