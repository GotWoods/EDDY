using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v5010._999;

public class LAK2_LIK3 {
	[SectionPosition(1)] public IK3_ImplementationDataSegmentNote ImplementationDataSegmentNote { get; set; } = new();
	[SectionPosition(2)] public List<CTX_Context> Context { get; set; } = new();
	[SectionPosition(3)] public List<LAK2__LIK3_LIK4> LIK4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAK2_LIK3>(this);
		validator.Required(x => x.ImplementationDataSegmentNote);
		validator.CollectionSize(x => x.Context, 0, 10);
		validator.CollectionSize(x => x.LIK4, 1, 2147483647);
		foreach (var item in LIK4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
