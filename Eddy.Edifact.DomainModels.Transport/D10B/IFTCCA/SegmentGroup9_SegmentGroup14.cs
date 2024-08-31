using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.IFTCCA;

public class SegmentGroup9_SegmentGroup14 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup9__SegmentGroup14_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9_SegmentGroup14>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 9);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
