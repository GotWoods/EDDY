using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._197;

public class LPID_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public N2_AdditionalNameInformation? AdditionalNameInformation { get; set; }
	[SectionPosition(3)] public N3_PartyLocation? PartyLocation { get; set; }
	[SectionPosition(4)] public N4_GeographicLocation? GeographicLocation { get; set; }
	[SectionPosition(5)] public List<LPID__LNM1_LEFI> LEFI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LPID_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.LEFI, 1, 2147483647);
		foreach (var item in LEFI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
