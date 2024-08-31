using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D14B;

namespace Eddy.Edifact.DomainModels.Transport.D14B.IFCSUM;

public class SegmentGroup27__SegmentGroup53_SegmentGroup62 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup27__SegmentGroup53__SegmentGroup62_SegmentGroup63> SegmentGroup63 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27__SegmentGroup53_SegmentGroup62>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup63, 0, 9);
		foreach (var item in SegmentGroup63) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
