/* Empiria Operations ****************************************************************************************
*                                                                                                            *
*  Module   : Suppliers Management                       Component : Domain Layer                            *
*  Assembly : Empiria.Procurement.Core.dll               Pattern   : Input fields DTO                        *
*  Type     : PaymentAccountFields                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Input fields DTO used to update payment accounts.                                              *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

namespace Empiria.Financial {

  /// <summary>Input fields DTO used to update payment accounts.</summary>
  public class PaymentAccountFields {

    public string UID {
      get; set;
    } = string.Empty;


    public string PartyUID {
      get; set;
    } = string.Empty;


    public string AccountTypeUID {
      get; set;
    } = string.Empty;


    public string PaymentMethodUID {
      get; set;
    } = string.Empty;


    public string InstitutionUID {
      get; set;
    } = string.Empty;


    public string AccountNo {
      get; set;
    } = string.Empty;


    public string Identificator {
      get; set;
    } = string.Empty;


    public string CurrencyUID {
      get; set;
    } = string.Empty;


    public string HolderName {
      get; set;
    } = string.Empty;


    public bool AskForReferenceNumber {
      get; set;
    }


    public string ReferenceNumber {
      get; set;
    } = string.Empty;


  }  // class PaymentAccountFields

}  // namespace Empiria.Financial
