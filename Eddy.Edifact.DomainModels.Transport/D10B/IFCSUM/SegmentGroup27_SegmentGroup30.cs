using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.IFCSUM;

public class SegmentGroup27_SegmentGroup30 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup27__SegmentGroup30_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27_SegmentGroup30>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 9);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
