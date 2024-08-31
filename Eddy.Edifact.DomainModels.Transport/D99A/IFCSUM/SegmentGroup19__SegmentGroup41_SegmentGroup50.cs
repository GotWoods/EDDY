using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;

namespace Eddy.Edifact.DomainModels.Transport.D99A.IFCSUM;

public class SegmentGroup19__SegmentGroup41_SegmentGroup50 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup19__SegmentGroup41__SegmentGroup50_SegmentGroup51> SegmentGroup51 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup41_SegmentGroup50>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup51, 0, 9);
		foreach (var item in SegmentGroup51) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
