using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B;

namespace Eddy.Edifact.DomainModels.Transport.D96B.IFTDGN;

public class SegmentGroup6_SegmentGroup8 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup6__SegmentGroup8_SegmentGroup9> SegmentGroup9 {get;set;} = new();
	[SectionPosition(3)] public RFF_Reference Reference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup8>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.Reference);
		foreach (var item in SegmentGroup9) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
