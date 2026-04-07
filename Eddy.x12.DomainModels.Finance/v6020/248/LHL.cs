using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._248;

public class LHL {
	[SectionPosition(1)] public HL_HierarchicalLevel HierarchicalLevel { get; set; } = new();
	[SectionPosition(2)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(3)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(4)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(5)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(6)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(7)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(8)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(9)] public List<AIN_Income> Income { get; set; } = new();
	[SectionPosition(10)] public List<EMS_EmploymentPosition> EmploymentPosition { get; set; } = new();
	[SectionPosition(11)] public BAL_BalanceDetail? BalanceDetail { get; set; }
	[SectionPosition(12)] public List<LHL_LDTP> LDTP {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL>(this);
		validator.Required(x => x.HierarchicalLevel);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.Income, 1, 2147483647);
		validator.CollectionSize(x => x.EmploymentPosition, 1, 2147483647);
		validator.CollectionSize(x => x.LDTP, 1, 2147483647);
		foreach (var item in LDTP) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
