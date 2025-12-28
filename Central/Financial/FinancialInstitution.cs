/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Common Storage Type                     *
*  Type     : FinancialInstitution                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a financial institution like a bank or a payments broker.                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.Financial {

  /// <summary>Represents a financial institution like a bank or a payments broker.</summary>
  public class FinancialInstitution : CommonStorage {

    #region Constructors and parsers

    protected FinancialInstitution() {
      // Required by Empiria Framework.
    }


    protected FinancialInstitution(PartyType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }

    static public FinancialInstitution Parse(int id) => ParseId<FinancialInstitution>(id);

    static public FinancialInstitution Parse(string uid) => ParseKey<FinancialInstitution>(uid);

    static public FinancialInstitution Empty => ParseEmpty<FinancialInstitution>();

    static public FixedList<FinancialInstitution> GetList() {
      return GetStorageObjects<FinancialInstitution>();
    }

    #endregion Constructors and parsers

    #region Properties

    public string BrokerCode {
      get {
        return base.Code;
      }
    }

    public string CommonName {
      get {
        return base.ExtData.Get("commonName", base.Name);
      }
    }

    #endregion Properties

  } // class FinancialInstitution

} // namespace Empiria.Financial
