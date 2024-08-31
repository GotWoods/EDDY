using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A;

namespace Eddy.Edifact.DomainModels.Transport.D98A.IFCSUM;

public class SegmentGroup19_SegmentGroup22 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup19__SegmentGroup22_SegmentGroup23> SegmentGroup23 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19_SegmentGroup22>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup23, 0, 9);
		foreach (var item in SegmentGroup23) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
