/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Financial                                  Component : Domain Layer                            *
*  Assembly : Empiria.Central.Core.dll                   Pattern   : Value type                              *
*  Type     : PaymentData                                License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Value type that holds information about a payment.                                             *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Json;

namespace Empiria.Financial {

  /// <summary>Value type that holds information about a payment.</summary>
  public class PaymentData {


    private PaymentData() {
      // Value types does not have a default constuctor/
    }

    public PaymentData(JsonObject json) {
      Assertion.Require(json, nameof(json));

      Id = json.Get("paymentId", -1);
      UID = json.Get("uid", string.Empty);
      PaymentNo = json.Get("paymentNo", string.Empty);
      PaymentDate = json.Get("paymentDate", ExecutionServer.DateMaxValue);
      Reference = json.Get("reference", string.Empty);
      BankID = json.Get("bankID", string.Empty);
      AccountNo = json.Get("accountNo", string.Empty);
    }


    static public PaymentData Parse(JsonObject json) {
      return new PaymentData(json);
    }


    public int Id {
      get;
    }

    public string UID {
      get;
    }


    public string PaymentNo {
      get;
    }


    public DateTime PaymentDate {
      get;
    }


    public string Reference {
      get;
    }


    public string BankID {
      get;
    }


    public string AccountNo {
      get;
    }


    public JsonObject ToJson() {
      var json = new JsonObject();

      json.AddIf("paymentId", Id, Id > 0);
      json.AddIfValue("uid", UID);
      json.AddIfValue("paymentNo", PaymentNo);
      json.AddIfValue("paymentDate", PaymentDate);
      json.AddIfValue("reference", Reference);
      json.AddIfValue("bankID", BankID);
      json.AddIfValue("accountNo", AccountNo);

      return json;
    }

  }  // interface PaymentData

}  // namespace Empiria.Financial
