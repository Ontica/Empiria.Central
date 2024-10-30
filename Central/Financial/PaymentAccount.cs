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
    public Organization Institution {
      get; private set;
    }


    [DataField("PYMT_ACCT_CURRENCY_ID")]
    public Currency Currency {
      get; private set;
    }


    public string Identificator {
      get {
        if (ExtData.HasValue("identificator")) {
          return ExtData.Get<string>("identificator");
        }
        if (CLABE.Length != 0) {
          return $"{Institution.CommonName} - {EmpiriaString.TruncateLast(CLABE, 4)}";
        } else if (AccountNo.Length != 0) {
          return $"{Institution.CommonName} - {EmpiriaString.TruncateLast(AccountNo, 4)}";
        } else {
          return Institution.CommonName;
        }
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


    public string AccountNo {
      get {
        return ExtData.Get("accountNo", string.Empty);
      }
      private set {
        ExtData.SetIfValue("accountNo", value);
      }
    }


    public string CLABE {
      get {
        return ExtData.Get("clabe", string.Empty);
      }
      private set {
        ExtData.SetIfValue("clabe", value);
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
        return EmpiriaString.BuildKeywords(AccountNo, HolderName, CLABE, Party.Keywords,
                                           Institution.Keywords, Identificator);
      }
    }

    #endregion Properties

  }  // class PaymentAccount

}  // namespace Empiria.Financial
