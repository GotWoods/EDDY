using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._820;

public class LLX_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public G53_MaintenanceType? MaintenanceType { get; set; }
	[SectionPosition(4)] public List<LLX__LNM1_LAIN> LAIN {get;set;} = new();
	[SectionPosition(5)] public List<LLX__LNM1_LPEN> LPEN {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.LAIN, 1, 2147483647);
		validator.CollectionSize(x => x.LPEN, 1, 2147483647);
		foreach (var item in LAIN) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPEN) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
