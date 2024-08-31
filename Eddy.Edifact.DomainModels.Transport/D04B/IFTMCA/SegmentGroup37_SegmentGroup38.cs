using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04B;

namespace Eddy.Edifact.DomainModels.Transport.D04B.IFTMCA;

public class SegmentGroup37_SegmentGroup38 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup37__SegmentGroup38_SegmentGroup39> SegmentGroup39 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup37_SegmentGroup38>(this);
		validator.Required(x => x.NameAndAddress);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.SegmentGroup39, 0, 9);
		foreach (var item in SegmentGroup39) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
