﻿/* Empiria Central  ******************************************************************************************
*                                                                                                            *
*  Module   : Parties                                    Component : Domain Layer                            *
*  Assembly : Empiria.Central.dll                        Pattern   : Information Holder                      *
*  Type     : Person                                     License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Represents a human person.                                                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties.Adapters;

namespace Empiria.Parties {

  /// <summary>Represents a human person.</summary>
  public class Person : Party {

    #region Constructors and parsers

    protected Person() {
      // Required by Empiria Framework.
    }


    protected Person(PartyType powertype) : base(powertype) {
      // Required by Empiria Framework for all partitioned types.
    }


    static public new Person Parse(int id) {
      return BaseObject.ParseId<Person>(id);
    }


    static public new Person Parse(string uid) {
      return BaseObject.ParseKey<Person>(uid);
    }


    public Person(PartyFields fields) {
      Assertion.Require(fields, nameof(fields));

      Update(fields);
    }


    static public new Person Empty => BaseObject.ParseEmpty<Person>();


    #endregion Constructors and parsers

    #region Properties

    public string FirstName {
      get {
        return base.ExtendedData.Get("person/firstName", string.Empty);
      }
      private set {
        base.ExtendedData.Set("person/firstName", EmpiriaString.TrimAll(value));
      }
    }


    public string LastName {
      get {
        return base.ExtendedData.Get("person/lastName", string.Empty);
      }
      private set {
        base.ExtendedData.Set("person/lastName", EmpiriaString.TrimAll(value));
      }
    }


    public string LastName2 {
      get {
        return base.ExtendedData.Get("person/lastName2", string.Empty);
      }
      private set {
        base.ExtendedData.Set("person/lastName2", EmpiriaString.TrimAll(value));
      }
    }


    public bool IsFemale {
      get {
        return ExtendedData.Get("person/isFemale", false);
      }
      private set {
        ExtendedData.Set("person/isFemale", value);
      }
    }


    public override string Keywords {
      get {
        return EmpiriaString.BuildKeywords(base.Keywords, LastName, LastName2, FirstName);
      }
    }

    public TaxData TaxData {
      get {
        return base.ExtendedData.Get("taxData", new TaxData());
      }
      private set {
        base.ExtendedData.SetIfValue("taxData", value.ToJson());
      }
    }

    #endregion Properties

    #region Methods

    public void SetTaxData(TaxDataFields fields) {
      Assertion.Require(fields, nameof(fields));

      this.TaxData = new TaxData(fields);
    }

    protected void Update(PersonFields fields) {
      base.Update(fields);

      this.FirstName  = PatchCleanField(fields.FirstName,   FirstName);
      this.LastName   = PatchCleanField(fields.LastName,    LastName);
      this.LastName2  = PatchCleanField(fields.LastName2,   LastName2);
      this.IsFemale = fields.IsFemale;
    }

    #endregion Methods

  } // class Person

} // namespace Empiria.Parties
