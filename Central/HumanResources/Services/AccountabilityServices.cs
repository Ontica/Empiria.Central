/* Empiria Central *******************************************************************************************
*                                                                                                            *
*  Module   : Human Resources                            Component : Services Layer                          *
*  Assembly : Empiria.Central.dll                        Pattern   : Services provider                       *
*  Type     : AccountabilityServices                     License   : Please read LICENSE.txt file            *
*                                                                                                            *
*  Summary  : Provides services to update and retrieve accountabilities.                                     *
*                                                                                                            *
************************* Copyright(c) La Vía Óntica SC, Ontica LLC and contributors. All rights reserved. **/

using Empiria.Services;

using Empiria.Parties;

using Empiria.HumanResources.Adapters;

namespace Empiria.HumanResources {

  /// <summary>Provides services to update and retrieve accountabilities.</summary>
  public class AccountabilityServices : Service {

    #region Constructors and parsers

    protected AccountabilityServices() {
      // no-op
    }

    static public AccountabilityServices ServiceInteractor() {
      return Service.CreateInstance<AccountabilityServices>();
    }

    #endregion Constructors and parsers

    #region Services

    public OrganizationalStructureHolder CreateAccountability(PartyRelationFields fields) {
      Assertion.Require(fields, nameof(fields));

      var accountability = new Accountability(fields.GetRole(),
                                              fields.GetCommissioner(),
                                              (Person) fields.GetResponsible());

      accountability.Update(fields);

      accountability.Save();

      return OrganizationalStructureMapper.Map((OrganizationalUnit) accountability.Commissioner);
    }


    public OrganizationalStructureHolder DeleteAccountability(string accountabilityUID) {
      Assertion.Require(accountabilityUID, nameof(accountabilityUID));

      var accountability = Accountability.Parse(accountabilityUID);

      accountability.Delete();

      accountability.Save();

      return OrganizationalStructureMapper.Map((OrganizationalUnit) accountability.Commissioner);
    }


    public AccountabilityDto GetAccountability(string accountabilityUID) {
      Assertion.Require(accountabilityUID, nameof(accountabilityUID));

      var accountability = Accountability.Parse(accountabilityUID);

      return AccountabilityMapper.Map(accountability);
    }


    public StructureForEditAccountabilities GetStructureForEditAccountabilities(string commissionerUID) {
      Assertion.Require(commissionerUID, nameof(commissionerUID));

      var commissioner = Party.Parse(commissionerUID);

      return StructureForEditAccountabilitiesMapper.Map(commissioner);
    }


    public FixedList<NamedEntityDto> SearchAvailableResponsibles(CommissionerResponsiblesQuery query) {
      Assertion.Require(query, nameof(query));

      var commissioner = Party.Parse(query.CommissionerUID);

      var role = PartyRole.Parse(query.PartyRoleUID);

      FixedList<Party> securityPlayers = role.SearchSecurityPlayers(query.Keywords);

      FixedList<Person> alreadyAssigned = Accountability.GetListFor(commissioner)
                                                        .FindAll(x => x.Role.Equals(role))
                                                        .SelectDistinct(x => x.Responsible);

      securityPlayers = securityPlayers.Remove(alreadyAssigned);

      return securityPlayers.MapToNamedEntityList();
    }


    public OrganizationalStructureHolder UpdateAccountability(PartyRelationFields fields) {
      Assertion.Require(fields, nameof(fields));

      var accountability = Accountability.Parse(fields.UID);

      accountability.Update(fields);

      accountability.Save();

      return OrganizationalStructureMapper.Map((OrganizationalUnit) accountability.Commissioner);
    }

    #endregion Services

  }  // class AccountabilityServices

}  // namespace Empiria.HumanResources
