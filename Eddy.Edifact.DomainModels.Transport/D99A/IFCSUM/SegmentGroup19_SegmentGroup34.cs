using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;

namespace Eddy.Edifact.DomainModels.Transport.D99A.IFCSUM;

public class SegmentGroup19_SegmentGroup34 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup19__SegmentGroup34_SegmentGroup35> SegmentGroup35 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup19__SegmentGroup34_SegmentGroup36> SegmentGroup36 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup19__SegmentGroup34_SegmentGroup37> SegmentGroup37 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup19__SegmentGroup34_SegmentGroup38> SegmentGroup38 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup19__SegmentGroup34_SegmentGroup39> SegmentGroup39 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup19__SegmentGroup34_SegmentGroup40> SegmentGroup40 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19_SegmentGroup34>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup35, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup36, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup37, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup38, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup39, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup40, 0, 99);
		foreach (var item in SegmentGroup35) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup36) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup37) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup38) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup39) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup40) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
