using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17A;

namespace Eddy.Edifact.DomainModels.Transport.D17A.IFTCCA;

public class SegmentGroup6 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup6_SegmentGroup7> SegmentGroup7 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup6_SegmentGroup8> SegmentGroup8 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup7, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup8, 0, 9);
		foreach (var item in SegmentGroup7) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup8) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
