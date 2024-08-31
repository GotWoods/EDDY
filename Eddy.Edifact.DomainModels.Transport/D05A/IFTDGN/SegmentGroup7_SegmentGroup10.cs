using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05A;

namespace Eddy.Edifact.DomainModels.Transport.D05A.IFTDGN;

public class SegmentGroup7_SegmentGroup10 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup7__SegmentGroup10_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(3)] public RFF_Reference Reference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7_SegmentGroup10>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.Reference);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
