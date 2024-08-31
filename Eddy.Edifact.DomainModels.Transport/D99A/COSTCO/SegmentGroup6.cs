using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;

namespace Eddy.Edifact.DomainModels.Transport.D99A.COSTCO;

public class SegmentGroup6 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 999);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
