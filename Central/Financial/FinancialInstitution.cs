/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : FinancialInstitution                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a financial institution like a bank or a payments broker.                           *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.Financial {

  /// <summary>Represents a financial institution like a bank or a payments broker.</summary>
  public class FinancialInstitution : Organization {

    #region Constructors and parsers

    protected FinancialInstitution() {
      // Required by Empiria Framework.
    }


    protected FinancialInstitution(PartyType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }


    static public new FinancialInstitution Parse(int id) => ParseId<FinancialInstitution>(id);

    static public new FinancialInstitution Parse(string uid) => ParseKey<FinancialInstitution>(uid);

    public FinancialInstitution(PartyFields fields) {
      Assertion.Require(fields, nameof(fields));

      Update(fields);
    }

    static public new FinancialInstitution Empty => ParseEmpty<FinancialInstitution>();

    #endregion Constructors and parsers

    #region Properties


    #endregion Properties

  } // class FinancialInstitution

} // namespace Empiria.Financial
