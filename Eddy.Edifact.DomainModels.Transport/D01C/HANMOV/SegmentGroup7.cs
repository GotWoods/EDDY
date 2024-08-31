using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.HANMOV;

public class SegmentGroup7 {
	[SectionPosition(1)] public TDT_DetailsOfTransport DetailsOfTransport { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup7_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7>(this);
		validator.Required(x => x.DetailsOfTransport);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
