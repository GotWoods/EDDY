using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D19A;

namespace Eddy.Edifact.DomainModels.Transport.D19A.IFTMBF;

public class SegmentGroup17_SegmentGroup24 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup17__SegmentGroup24_SegmentGroup25> SegmentGroup25 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup17_SegmentGroup24>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup25, 0, 9);
		foreach (var item in SegmentGroup25) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
