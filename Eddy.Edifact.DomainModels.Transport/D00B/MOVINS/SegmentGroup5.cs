using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B;

namespace Eddy.Edifact.DomainModels.Transport.D00B.MOVINS;

public class SegmentGroup5 {
	[SectionPosition(1)] public HAN_HandlingInstructions HandlingInstructions { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup5_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5>(this);
		validator.Required(x => x.HandlingInstructions);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9999);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
