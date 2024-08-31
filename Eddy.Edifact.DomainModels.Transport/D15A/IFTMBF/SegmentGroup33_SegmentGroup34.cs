using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15A;

namespace Eddy.Edifact.DomainModels.Transport.D15A.IFTMBF;

public class SegmentGroup33_SegmentGroup34 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup33__SegmentGroup34_SegmentGroup35> SegmentGroup35 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup33_SegmentGroup34>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.SegmentGroup35, 0, 9);
		foreach (var item in SegmentGroup35) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
