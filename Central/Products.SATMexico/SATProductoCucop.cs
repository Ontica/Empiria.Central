/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Products SAT Mexico                        Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : SATProductoCucop                           License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Producto o servicio con partidas presupuestales del gasto corriente, de acuerdo al             *
*             catálogo CUCoP (Clasificador Único de las Contrataciones Públicas) del SAT México.             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Products.SATMexico {

  /// <summary>Producto o servicio con partidas presupuestales del gasto corriente, de acuerdo al
  /// catálogo CUCoP (Clasificador Único de las Contrataciones Públicas) del SAT México.</summary>
  public class SATProductoCucop : SATDataItem {

    #region Constructors and parsers

    static public SATProductoCucop Parse(int id) => ParseId<SATProductoCucop>(id);

    static public SATProductoCucop Parse(string uid) => ParseKey<SATProductoCucop>(uid);

    static public FixedList<SATProductoCucop> GetList() {
      return BaseObject.GetList<SATProductoCucop>()
                       .ToFixedList();
    }

    static public SATProductoCucop Empty => ParseEmpty<SATProductoCucop>();

    #endregion Constructors and parsers

    #region Properties

    public string Partida {
      get {
        return base.Field01;
      }
      private set {
        base.Field01 = EmpiriaString.Clean(value);
      }
    }


    public string NombrePartida {
      get {
        return base.Field02;
      }
      private set {
        base.Field02 = EmpiriaString.Clean(value);
      }
    }

    public string Concepto {
      get {
        return base.Field03;
      }
      private set {
        base.Field03 = EmpiriaString.Clean(value);
      }
    }


    public string NombreConcepto {
      get {
        return base.Field04;
      }
      private set {
        base.Field04 = EmpiriaString.Clean(value);
      }
    }

    #endregion Properties

  } // class SATProductoCucop

} // namespace Empiria.Products.SATMexico
