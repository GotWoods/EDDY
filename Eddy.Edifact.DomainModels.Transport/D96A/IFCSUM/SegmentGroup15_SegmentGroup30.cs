using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup15_SegmentGroup30 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup15__SegmentGroup30_SegmentGroup31> SegmentGroup31 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup15__SegmentGroup30_SegmentGroup32> SegmentGroup32 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup15__SegmentGroup30_SegmentGroup33> SegmentGroup33 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup15__SegmentGroup30_SegmentGroup34> SegmentGroup34 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup15__SegmentGroup30_SegmentGroup35> SegmentGroup35 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup15__SegmentGroup30_SegmentGroup36> SegmentGroup36 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup15_SegmentGroup30>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup31, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup32, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup33, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup34, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup35, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup36, 0, 99);
		foreach (var item in SegmentGroup31) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup32) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup33) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup34) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup35) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup36) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
