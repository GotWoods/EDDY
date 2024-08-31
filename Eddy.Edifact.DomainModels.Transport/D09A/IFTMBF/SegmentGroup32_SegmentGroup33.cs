using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09A;

namespace Eddy.Edifact.DomainModels.Transport.D09A.IFTMBF;

public class SegmentGroup32_SegmentGroup33 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup32__SegmentGroup33_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup32_SegmentGroup33>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 9);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
