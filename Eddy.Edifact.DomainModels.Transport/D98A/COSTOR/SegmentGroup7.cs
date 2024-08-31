using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A;

namespace Eddy.Edifact.DomainModels.Transport.D98A.COSTOR;

public class SegmentGroup7 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup7_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 999);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
