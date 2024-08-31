using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09A;

namespace Eddy.Edifact.DomainModels.Transport.D09A.IFTMCA;

public class SegmentGroup17_SegmentGroup26 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup17__SegmentGroup26_SegmentGroup27> SegmentGroup27 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup17_SegmentGroup26>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup27, 0, 9);
		foreach (var item in SegmentGroup27) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
