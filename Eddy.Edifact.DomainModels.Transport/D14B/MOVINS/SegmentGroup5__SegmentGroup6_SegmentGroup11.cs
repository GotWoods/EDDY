using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D14B;

namespace Eddy.Edifact.DomainModels.Transport.D14B.MOVINS;

public class SegmentGroup5__SegmentGroup6_SegmentGroup11 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup5__SegmentGroup6__SegmentGroup11_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5__SegmentGroup6_SegmentGroup11>(this);
		validator.Required(x => x.Reference);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 99);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
