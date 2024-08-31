using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01A;

namespace Eddy.Edifact.DomainModels.Transport.D01A.COEDOR;

public class SegmentGroup4_SegmentGroup6 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup4__SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4_SegmentGroup6>(this);
		validator.Required(x => x.DetailsOfTransport);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 9);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
