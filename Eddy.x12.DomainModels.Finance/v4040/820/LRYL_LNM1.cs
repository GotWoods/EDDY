using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._820;

public class LRYL_LNM1 {
	[SectionPosition(1)] public NM1_IndividualOrOrganizationalName IndividualOrOrganizationalName { get; set; } = new();
	[SectionPosition(2)] public List<LRYL__LNM1_LLOC> LLOC {get;set;} = new();
	[SectionPosition(3)] public List<LRYL__LNM1_LASM> LASM {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LRYL_LNM1>(this);
		validator.Required(x => x.IndividualOrOrganizationalName);
		validator.CollectionSize(x => x.LLOC, 1, 2147483647);
		foreach (var item in LLOC) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LASM) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
