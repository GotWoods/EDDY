using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A;

namespace Eddy.Edifact.DomainModels.Transport.D97A.HANMOV;

public class SegmentGroup3 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DOC_DocumentMessageDetails> DocumentMessageDetails { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup3_SegmentGroup4> SegmentGroup4 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup3_SegmentGroup5> SegmentGroup5 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.DocumentMessageDetails, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup4, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup5, 0, 9);
		foreach (var item in SegmentGroup4) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup5) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
