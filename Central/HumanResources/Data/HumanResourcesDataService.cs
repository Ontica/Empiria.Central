/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : History Services                          Component : Data Layer                               *
*  Assembly : Empiria.Central.dll                       Pattern   : Data access services provider            *
*  Type     : HumanResourcesDataService                 License   : Please read LICENSE.txt file             *
*                                                                                                            *
*  Summary  : Data persistance services for human resources.                                                 *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Data;

using Empiria.Parties;

namespace Empiria.HumanResources {

  /// <summary>Data persistance services for human resources.</summary>
  static internal class HumanResourcesDataService {

    static internal FixedList<OrganizationalUnit> SearchOrganizationalUnits(string filter, string sort) {

      Assertion.Require(filter, nameof(filter));
      Assertion.Require(sort, nameof(sort));

      var sql = "SELECT * FROM PARTIES " +
               $"WHERE {filter} " +
               $"ORDER BY {sort}";

      var op = DataOperation.Parse(sql);

      return DataReader.GetFixedList<OrganizationalUnit>(op);
    }

  }  // class HumanResourcesDataService

}  // namespace Empiria.History
