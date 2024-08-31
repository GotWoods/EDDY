using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.MOVINS;

public class SegmentGroup3__SegmentGroup4_SegmentGroup9 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup3__SegmentGroup4__SegmentGroup9_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3__SegmentGroup4_SegmentGroup9>(this);
		validator.Required(x => x.Reference);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 99);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
