using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.BERMAN;

public class SegmentGroup3_SegmentGroup5 {
	[SectionPosition(1)] public GOR_GovernmentalRequirements GovernmentalRequirements { get; set; } = new();
	[SectionPosition(2)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(3)] public List<NAD_NameAndAddress> NameAndAddress { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup3__SegmentGroup5_SegmentGroup6> SegmentGroup6 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3_SegmentGroup5>(this);
		validator.Required(x => x.GovernmentalRequirements);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.NameAndAddress, 1, 99);
		validator.CollectionSize(x => x.SegmentGroup6, 0, 9);
		foreach (var item in SegmentGroup6) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
