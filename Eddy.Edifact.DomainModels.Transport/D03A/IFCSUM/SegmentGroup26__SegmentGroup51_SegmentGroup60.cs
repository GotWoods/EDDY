using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D03A;

namespace Eddy.Edifact.DomainModels.Transport.D03A.IFCSUM;

public class SegmentGroup26__SegmentGroup51_SegmentGroup60 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup26__SegmentGroup51__SegmentGroup60_SegmentGroup61> SegmentGroup61 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51_SegmentGroup60>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup61, 0, 9);
		foreach (var item in SegmentGroup61) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
