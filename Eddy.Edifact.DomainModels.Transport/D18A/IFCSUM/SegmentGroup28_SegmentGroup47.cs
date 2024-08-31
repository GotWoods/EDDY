using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18A;

namespace Eddy.Edifact.DomainModels.Transport.D18A.IFCSUM;

public class SegmentGroup28_SegmentGroup47 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup28__SegmentGroup47_SegmentGroup48> SegmentGroup48 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup28__SegmentGroup47_SegmentGroup49> SegmentGroup49 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup28__SegmentGroup47_SegmentGroup50> SegmentGroup50 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup28__SegmentGroup47_SegmentGroup51> SegmentGroup51 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup28__SegmentGroup47_SegmentGroup52> SegmentGroup52 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup28__SegmentGroup47_SegmentGroup53> SegmentGroup53 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup47>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup48, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup49, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup50, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup51, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup52, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup53, 0, 99);
		foreach (var item in SegmentGroup48) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup49) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup50) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup51) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup52) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup53) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
