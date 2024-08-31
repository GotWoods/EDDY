using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05A;

namespace Eddy.Edifact.DomainModels.Transport.D05A.IFTMBP;

public class SegmentGroup29_SegmentGroup30 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup29__SegmentGroup30_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup29_SegmentGroup30>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 9);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
