using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.MOVINS;

public class SegmentGroup6 {
	[SectionPosition(1)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.HandlingInstructions);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 99999);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
