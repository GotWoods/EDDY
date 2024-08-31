using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup5_SegmentGroup9 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup5__SegmentGroup9_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup5__SegmentGroup9_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup5__SegmentGroup9_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5_SegmentGroup9>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 9);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
