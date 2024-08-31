using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D03B;

namespace Eddy.Edifact.DomainModels.Transport.D03B.COSTCO;

public class SegmentGroup10 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup10_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup10>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 999);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
