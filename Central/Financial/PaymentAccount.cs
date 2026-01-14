/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : PaymentAccount                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a payment account.                                                                  *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Json;
using Empiria.Parties;
using Empiria.StateEnums;

namespace Empiria.Financial {

  /// <summary>Represents a payment account.</summary>
  public class PaymentAccount : BaseObject, INamedEntity {

    #region Constructors and parsers

    static public PaymentAccount Parse(int id) => ParseId<PaymentAccount>(id);

    static public PaymentAccount Parse(string uid) => ParseKey<PaymentAccount>(uid);

    static public FixedList<PaymentAccount> GetListFor(Party party) {
      return BaseObject.GetList<PaymentAccount>()
                       .ToFixedList()
                       .FindAll(x => x.Party.Equals(party));
    }

    static public PaymentAccount Empty => ParseEmpty<PaymentAccount>();

    #endregion Constructors and parsers

    #region Properties

    [DataField("PYMT_ACCT_TYPE_ID")]
    public PaymentAccountType AccountType {
      get; private set;
    }


    string INamedEntity.Name {
      get {
        return this.Identificator;
      }
    }


    [DataField("PYMT_ACCT_PARTY_ID")]
    public Party Party {
      get; private set;
    }


    [DataField("PYMT_ACCT_METHOD_ID")]
    public PaymentMethod PaymentMethod {
      get; private set;
    }


    [DataField("PYMT_ACCT_INSTITUTION_ID")]
    public FinancialInstitution Institution {
      get; private set;
    }


    [DataField("PYMT_ACCT_CURRENCY_ID")]
    public Currency Currency {
      get; private set;
    }


    [DataField("PYMT_ACCT_NUMBER")]
    public string AccountNo {
      get; private set;
    }

    public string Identificator {
      get {
        if (ExtData.HasValue("identificator")) {
          return $"{Institution.CommonName} ({ExtData.Get<string>("identificator")}) - " +
                 $"{EmpiriaString.TruncateLast(AccountNo, 4)}";
        }
        return $"{Institution.CommonName} - {EmpiriaString.TruncateLast(AccountNo, 4)}";
      }
      private set {
        ExtData.SetIfValue("identificator", value);
      }
    }


    public string HolderName {
      get {
        return ExtData.Get("holderName", Party.Name);
      }
      private set {
        ExtData.SetIfValue("holderName", value);
      }
    }

    public string ReferenceNumber {
      get {
        return ExtData.Get("referenceNumber", string.Empty);
      }
      private set {
        ExtData.SetIfValue("referenceNumber", value);
      }
    }


    [DataField("PYMT_ACCT_EXT_DATA")]
    internal JsonObject ExtData {
      get; private set;
    }


    [DataField("PYMT_ACCT_POSTED_BY_ID")]
    public Party PostedBy {
      get; private set;
    }


    [DataField("PYMT_ACCT_POSTING_TIME")]
    public DateTime PostingTime {
      get; private set;
    }


    [DataField("PYMT_ACCT_STATUS", Default = EntityStatus.Active)]
    public EntityStatus Status {
      get; private set;
    }


    public string Keywords {
      get {
        return EmpiriaString.BuildKeywords(AccountNo, HolderName, Party.Keywords,
                                           Institution.Keywords, Identificator);
      }
    }

    public bool AskForReferenceNumber {
      get {
        return ExtData.Get("askForReferenceNumber", false);
      }
      private set {
        ExtData.SetIf("askForReferenceNumber", value, value == true);
      }
    }

    #endregion Properties

    #region Methods


    protected override void OnSave() {
      if (IsNew) {
        PostedBy = Party.ParseWithContact(ExecutionServer.CurrentContact);
        PostingTime = DateTime.Now;
      }

      PaymentAccountData.Write(this);
    }


    public void Update(PaymentAccountFields fields) {
      Assertion.Require(fields, nameof(fields));

      AccountType = PaymentAccountType.Parse(fields.AccountTypeUID);
      PaymentMethod = PaymentMethod.Parse(fields.PaymentMethodUID);
      Institution = FinancialInstitution.Parse(fields.InstitutionUID);
      AccountNo = EmpiriaString.Clean(fields.AccountNo);
      Identificator = EmpiriaString.Clean(fields.Identificator);
      Currency = Currency.Parse(fields.CurrencyUID);
      HolderName = EmpiriaString.Clean(fields.HolderName);
      AskForReferenceNumber = fields.AskForReferenceNumber;
      ReferenceNumber = EmpiriaString.Clean(fields.ReferenceNumber);

      MarkAsDirty();
    }

    #endregion Methods

  }  // class PaymentAccount

}  // namespace Empiria.Financial
