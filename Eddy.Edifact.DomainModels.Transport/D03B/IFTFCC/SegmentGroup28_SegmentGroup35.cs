using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D03B;

namespace Eddy.Edifact.DomainModels.Transport.D03B.IFTFCC;

public class SegmentGroup28_SegmentGroup35 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<SegmentGroup28__SegmentGroup35_SegmentGroup36> SegmentGroup36 {get;set;} = new();
	[SectionPosition(3)] public List<RFF_Reference> Reference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup35>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup36, 0, 9);
		foreach (var item in SegmentGroup36) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
