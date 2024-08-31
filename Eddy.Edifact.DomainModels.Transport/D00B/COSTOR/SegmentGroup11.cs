using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B;

namespace Eddy.Edifact.DomainModels.Transport.D00B.COSTOR;

public class SegmentGroup11 {
	[SectionPosition(1)] public CNI_ConsignmentInformation ConsignmentInformation { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup11_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup11>(this);
		validator.Required(x => x.ConsignmentInformation);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.NameAndAddress, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 999);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
