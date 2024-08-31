using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D15A;

namespace Eddy.Edifact.DomainModels.Transport.D15A.IFTSTA;

public class SegmentGroup13__SegmentGroup14_SegmentGroup16 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup13__SegmentGroup14__SegmentGroup16_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13__SegmentGroup14_SegmentGroup16>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 9);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
