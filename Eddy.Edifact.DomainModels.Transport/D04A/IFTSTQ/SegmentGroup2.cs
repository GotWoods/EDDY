using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04A;

namespace Eddy.Edifact.DomainModels.Transport.D04A.IFTSTQ;

public class SegmentGroup2 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup2_SegmentGroup3> SegmentGroup3 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup2>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.SegmentGroup3, 0, 9);
		foreach (var item in SegmentGroup3) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
