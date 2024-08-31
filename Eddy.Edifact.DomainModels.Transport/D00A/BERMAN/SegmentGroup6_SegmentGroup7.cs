using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A;

namespace Eddy.Edifact.DomainModels.Transport.D00A.BERMAN;

public class SegmentGroup6_SegmentGroup7 {
	[SectionPosition(1)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(2)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup6__SegmentGroup7_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup7>(this);
		validator.Required(x => x.HandlingInstructions);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
