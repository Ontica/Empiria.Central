/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Adapters Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Mapper                                  *
*  Type     : AccountabilityMapper                       License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Mapping services for accountability data.                                                      *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Parties;

namespace Empiria.HumanResources {

  /// <summary>Mapping services for accountability data.</summary>
  static public class AccountabilityMapper {

    static internal FixedList<AccountabilityDescriptor> Map(OrganizationalUnit orgUnit) {

      FixedList<Accountability> accountabilities = Accountability.GetListFor(orgUnit);

      return accountabilities.Select(x => MapToDescriptor(x))
                     .ToFixedList();

    }


    static private AccountabilityDescriptor MapToDescriptor(Accountability accountability) {

      return new AccountabilityDescriptor {
        UID = accountability.UID,
        ResponsibleName = accountability.Responsible.Name,
        RoleName = accountability.Role.Name,
        CommissionerName = accountability.Commissioner.Name,
        StartDate = accountability.StartDate,
        EndDate = accountability.EndDate,
      };
    }

  }  // class AccountabilityMapper

}  // namespace Empiria.HumanResources
