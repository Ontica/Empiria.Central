/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Documents                                  Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Input Fields DTO                        *
*  Type     : DocumentFields                             License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input fields DTO used to create and update Document  instances.                                *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Parties;
using Empiria.Products;

namespace Empiria.Documents {

  /// <summary>Input fields DTO used to create and update Document instances.</summary>
  public class DocumentFields : NamedEntityFields {

    public string DocumentProductUID {
      get; set;
    } = string.Empty;


    public string DocumentNumber {
      get; set;
    } = string.Empty;


    public string Description {
      get; set;
    } = string.Empty;


    public string[] Tags {
      get; set;
    } = new string[0];


    public string SourcePartyUID {
      get; set;
    } = string.Empty;


    public string TargetPartyUID {
      get; set;
    } = string.Empty;


    public string SignedByUID {
      get; set;
    } = string.Empty;


    public DateTime DocumentDate {
      get; set;
    } = ExecutionServer.DateMaxValue;


    public decimal Total {
      get; set;
    }

  }  // class DocumentFields


  /// <summary>Extension methods for DocumentFields.</summary>
  public static class DocumentFieldsExtensions {

    static internal void EnsureValid(this DocumentFields fields) {
      fields.Name = EmpiriaString.Clean(fields.Name);
      fields.DocumentNumber = EmpiriaString.Clean(fields.DocumentNumber);
      fields.Description = EmpiriaString.Clean(fields.Description);

      if (fields.DocumentProductUID.Length != 0) {
        _ = Product.Parse(fields.DocumentProductUID);
      }
      if (fields.SourcePartyUID.Length != 0) {
        _ = Party.Parse(fields.SourcePartyUID);
      }
      if (fields.TargetPartyUID.Length != 0) {
        _ = Party.Parse(fields.TargetPartyUID);
      }
      if (fields.SignedByUID.Length != 0) {
        _ = Party.Parse(fields.SignedByUID);
      }
    }

  }  // class ProductFieldsExtensions

}  // namespace Empiria.Documents
