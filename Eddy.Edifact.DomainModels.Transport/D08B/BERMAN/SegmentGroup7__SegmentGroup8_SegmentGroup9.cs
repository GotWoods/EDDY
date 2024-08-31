using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08B;

namespace Eddy.Edifact.DomainModels.Transport.D08B.BERMAN;

public class SegmentGroup7__SegmentGroup8_SegmentGroup9 {
	[SectionPosition(1)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(2)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup7__SegmentGroup8__SegmentGroup9_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7__SegmentGroup8_SegmentGroup9>(this);
		validator.Required(x => x.HandlingInstructions);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 9);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
