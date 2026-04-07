using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._194;

public class LHL_LPPL {
	[SectionPosition(1)] public PPL_PriceSupportData PriceSupportData { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	[SectionPosition(3)] public List<LHL__LPPL_LPD> LPD {get;set;} = new();
	[SectionPosition(4)] public List<LHL__LPPL_LPL> LPL {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LPPL>(this);
		validator.Required(x => x.PriceSupportData);
		validator.CollectionSize(x => x.ReferenceInformation, 1, 2147483647);
		validator.CollectionSize(x => x.LPD, 1, 2147483647);
		validator.CollectionSize(x => x.LPL, 1, 2147483647);
		foreach (var item in LPD) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LPL) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
