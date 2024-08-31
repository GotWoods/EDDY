using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.IFCSUM;

public class SegmentGroup26_SegmentGroup29 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup26__SegmentGroup29_SegmentGroup30> SegmentGroup30 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26_SegmentGroup29>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup30, 0, 9);
		foreach (var item in SegmentGroup30) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
