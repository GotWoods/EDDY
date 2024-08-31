using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup25__SegmentGroup50_SegmentGroup59 {
	[SectionPosition(1)] public TPL_TransportPlacement TransportPlacement { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup25__SegmentGroup50__SegmentGroup59_SegmentGroup60> SegmentGroup60 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup50_SegmentGroup59>(this);
		validator.Required(x => x.TransportPlacement);
		validator.CollectionSize(x => x.SegmentGroup60, 0, 9);
		foreach (var item in SegmentGroup60) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
