using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17A;

namespace Eddy.Edifact.DomainModels.Transport.D17A.IFTMBP;

public class SegmentGroup30_SegmentGroup31 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup30__SegmentGroup31_SegmentGroup32> SegmentGroup32 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup30_SegmentGroup31>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 9);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
