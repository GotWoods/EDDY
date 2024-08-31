using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04A;

namespace Eddy.Edifact.DomainModels.Transport.D04A.IFTMCS;

public class SegmentGroup18_SegmentGroup25 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup18__SegmentGroup25_SegmentGroup26> SegmentGroup26 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup18_SegmentGroup25>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup26, 0, 9);
		foreach (var item in SegmentGroup26) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
