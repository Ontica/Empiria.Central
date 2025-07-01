/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Services Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Services provider                       *
*  Type     : ResponsibleAccountabilityServices          License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides services to update and retrieve resposible accountabilities.                          *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using System;

using Empiria.Parties;
using Empiria.Services;

using Empiria.HumanResources.Adapters;

namespace Empiria.HumanResources {

  /// <summary>Provides services to update and retrieve resposible accountabilities.</summary>
  public class ResponsibleAccountabilityServices : Service {

    #region Constructors and parsers

    protected ResponsibleAccountabilityServices() {
      // no-op
    }

    static public ResponsibleAccountabilityServices ServiceInteractor() {
      return Service.CreateInstance<ResponsibleAccountabilityServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public FixedList<AccountabilityDescriptor> CreateAccountability(PartyRelationFields fields) {
      Assertion.Require(fields, nameof(fields));

      var accountability = new Accountability(fields.GetRole(),
                                              fields.GetCommissioner(),
                                              (Person) fields.GetResponsible());

      accountability.Update(fields);

      accountability.Save();

      var accountabilities = Accountability.GetListForResponsible(accountability.Responsible);

      return AccountabilityMapper.Map(accountabilities);
    }


    public FixedList<AccountabilityDescriptor> DeleteAccountability(string accountabilityUID) {
      Assertion.Require(accountabilityUID, nameof(accountabilityUID));

      var accountability = Accountability.Parse(accountabilityUID);

      accountability.Delete();

      accountability.Save();

      var accountabilities = Accountability.GetListForResponsible(accountability.Responsible);

      return AccountabilityMapper.Map(accountabilities);
    }


    public FixedList<AccountabilityDescriptor> GetAccountabilities(string responsibleUID) {
      Assertion.Require(responsibleUID, nameof(responsibleUID));

      var responsible = Party.Parse(responsibleUID);

      var accountabilities = Accountability.GetListForResponsible(responsible);

      return AccountabilityMapper.Map(accountabilities);
    }


    public AccountabilityDto GetAccountability(string accountabilityUID) {
      Assertion.Require(accountabilityUID, nameof(accountabilityUID));

      var accountability = Accountability.Parse(accountabilityUID);

      return AccountabilityMapper.Map(accountability);
    }


    public StructureForEditAccountabilities GetStructureForEditAccountabilities(string responsibleUID) {
      Assertion.Require(responsibleUID, nameof(responsibleUID));

      var responsible = Party.Parse(responsibleUID);

      FixedList<string> resposibleRoles = responsible.GetSecurityRoles()
                                                     .FindAll(x => !x.HasOrganizationalScope)
                                                     .SelectDistinctFlat(x => x.AppliesTo);

      FixedList<PartyRole> availableRoles = PartyRole.GetList()
                                                     .FindAll(x => x.AppliesTo.Intersect(resposibleRoles).Count != 0);

      return StructureForEditAccountabilitiesMapper.Map(responsible, availableRoles);
    }


    public FixedList<NamedEntityDto> SearchAvailableCommissioners(CommissionerResponsiblesQuery query) {
      Assertion.Require(query, nameof(query));

      var responsible = Party.Parse(query.ResponsibleUID);

      var role = PartyRole.Parse(query.PartyRoleUID);

      string keywords = SearchExpression.ParseAndLikeKeywords("PARTY_KEYWORDS", query.Keywords);

      FixedList<OrganizationalUnit> commissioners = Party.GetFullList<OrganizationalUnit>(keywords, "PARTY_CODE")
                                                         .FindAll(x => x.Roles.Intersect(role.AppliesTo).Count != 0);

      FixedList<OrganizationalUnit> alreadyAssigned = Accountability.GetListForResponsible(responsible)
                                                                    .FindAll(x => x.Role.Equals(role))
                                                                    .SelectDistinct(x => (OrganizationalUnit) x.Commissioner);

      commissioners = commissioners.Remove(alreadyAssigned);

      return commissioners.MapToNamedEntityList();
    }


    public FixedList<AccountabilityDescriptor> UpdateAccountability(PartyRelationFields fields) {
      Assertion.Require(fields, nameof(fields));

      var accountability = Accountability.Parse(fields.UID);

      accountability.Update(fields);

      accountability.Save();

      var accountabilities = Accountability.GetListForResponsible(accountability.Responsible);

      return AccountabilityMapper.Map(accountabilities);
    }

    #endregion Services

  }  // class ResponsibleAccountabilityServices

}  // namespace Empiria.HumanResources
