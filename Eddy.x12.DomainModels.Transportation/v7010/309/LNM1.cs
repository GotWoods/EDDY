using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Transportation.v7010._309;

public class LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public DMG_DemographicInformation? DemographicInformation { get; set; }
	[SectionPosition(3)] public DMA_AdditionalDemographicInformation? AdditionalDemographicInformation { get; set; }
	[SectionPosition(4)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(5)] public List<N3_PartyLocation> PartyLocation { get; set; } = new();
	[SectionPosition(6)] public N4_GeographicLocation? GeographicLocation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 10);
		validator.CollectionSize(x => x.PartyLocation, 0, 2);
		return validator.Results;
	}
}
