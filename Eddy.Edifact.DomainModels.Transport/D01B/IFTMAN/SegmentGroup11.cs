using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01B;

namespace Eddy.Edifact.DomainModels.Transport.D01B.IFTMAN;

public class SegmentGroup11 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup11_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup11_SegmentGroup13> SegmentGroup13 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup11_SegmentGroup14> SegmentGroup14 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup11_SegmentGroup15> SegmentGroup15 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup11_SegmentGroup16> SegmentGroup16 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup11_SegmentGroup17> SegmentGroup17 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup11>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup13, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup14, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup15, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup16, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup17, 0, 99);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup13) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup14) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup15) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup16) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup17) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
