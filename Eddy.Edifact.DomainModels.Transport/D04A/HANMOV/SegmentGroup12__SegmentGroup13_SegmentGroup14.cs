using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04A;

namespace Eddy.Edifact.DomainModels.Transport.D04A.HANMOV;

public class SegmentGroup12__SegmentGroup13_SegmentGroup14 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup12__SegmentGroup13__SegmentGroup14_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup12__SegmentGroup13_SegmentGroup14>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 9);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
