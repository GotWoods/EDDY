using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.MOVINS;

public class SegmentGroup3 {
	[SectionPosition(1)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup3_SegmentGroup4> SegmentGroup4 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3>(this);
		validator.Required(x => x.HandlingInstructions);
		validator.CollectionSize(x => x.SegmentGroup4, 0, 9999);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
