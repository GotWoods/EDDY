using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D02A;

namespace Eddy.Edifact.DomainModels.Transport.D02A.IFCSUM;

public class SegmentGroup9_SegmentGroup17 {
	[SectionPosition(1)] public NAD_NameAndAddress NameAndAddress { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup9__SegmentGroup17_SegmentGroup18> SegmentGroup18 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup9__SegmentGroup17_SegmentGroup19> SegmentGroup19 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup9__SegmentGroup17_SegmentGroup20> SegmentGroup20 {get;set;} = new();
	[SectionPosition(6)] public List<SegmentGroup9__SegmentGroup17_SegmentGroup21> SegmentGroup21 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9_SegmentGroup17>(this);
		validator.Required(x => x.NameAndAddress);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup18, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup19, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup20, 0, 9);
		validator.CollectionSize(x => x.SegmentGroup21, 0, 9);
		foreach (var item in SegmentGroup18) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup19) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup20) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup21) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
