using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5050;

namespace Eddy.x12.DomainModels.Transportation.v5050._284;

public class LHL_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<N2_AdditionalNameInformation> AdditionalNameInformation { get; set; } = new();
	[SectionPosition(3)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<N9_ExtendedReferenceInformation> ExtendedReferenceInformation { get; set; } = new();
	[SectionPosition(6)] public List<PER_AdministrativeCommunicationsContact> AdministrativeCommunicationsContact { get; set; } = new();
	[SectionPosition(7)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(8)] public List<DMG_DemographicInformation> DemographicInformation { get; set; } = new();
	[SectionPosition(9)] public DMA_AdditionalDemographicInformation? AdditionalDemographicInformation { get; set; }
	[SectionPosition(10)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(11)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(12)] public List<LHL__LNM1_LLIE> LLIE {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.AdditionalNameInformation, 0, 2);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		validator.CollectionSize(x => x.ExtendedReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.AdministrativeCommunicationsContact, 1, 2147483647);
		validator.CollectionSize(x => x.DemographicInformation, 1, 2147483647);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 1, 2147483647);
		validator.CollectionSize(x => x.LLIE, 1, 2147483647);
		foreach (var item in LLIE) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
