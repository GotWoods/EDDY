using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A;

namespace Eddy.Edifact.DomainModels.Transport.D98A.IFCSUM;

public class SegmentGroup8_SegmentGroup12 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup8__SegmentGroup12_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup8__SegmentGroup12_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup8__SegmentGroup12_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup8__SegmentGroup12_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup8_SegmentGroup12>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 9);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
