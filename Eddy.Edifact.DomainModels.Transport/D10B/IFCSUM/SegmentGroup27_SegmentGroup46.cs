using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.IFCSUM;

public class SegmentGroup27_SegmentGroup46 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(4)] public List<SegmentGroup27__SegmentGroup46_SegmentGroup47> SegmentGroup47 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup27__SegmentGroup46_SegmentGroup48> SegmentGroup48 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup27__SegmentGroup46_SegmentGroup49> SegmentGroup49 {get;set;} = new();
	[SectionPosition(7)] public List<SegmentGroup27__SegmentGroup46_SegmentGroup50> SegmentGroup50 {get;set;} = new();
	[SectionPosition(8)] public List<SegmentGroup27__SegmentGroup46_SegmentGroup51> SegmentGroup51 {get;set;} = new();
	[SectionPosition(9)] public List<SegmentGroup27__SegmentGroup46_SegmentGroup52> SegmentGroup52 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup27_SegmentGroup46>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup47, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup48, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup49, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup50, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup51, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup52, 0, 99);
		foreach (var item in SegmentGroup47) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup48) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup49) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup50) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup51) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup52) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
