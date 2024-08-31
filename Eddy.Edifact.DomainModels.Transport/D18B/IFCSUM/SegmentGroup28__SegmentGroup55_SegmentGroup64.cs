using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18B;

namespace Eddy.Edifact.DomainModels.Transport.D18B.IFCSUM;

public class SegmentGroup28__SegmentGroup55_SegmentGroup64 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup28__SegmentGroup55__SegmentGroup64_SegmentGroup65> SegmentGroup65 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup55_SegmentGroup64>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup65, 0, 9);
		foreach (var item in SegmentGroup65) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
