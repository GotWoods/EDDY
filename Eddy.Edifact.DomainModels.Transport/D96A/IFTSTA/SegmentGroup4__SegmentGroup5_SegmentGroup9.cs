using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFTSTA;

public class SegmentGroup4__SegmentGroup5_SegmentGroup9 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public List<HAN_HandlingInstructions> HandlingInstructions { get; set; } = new();
	[SectionPosition(3)] public List<SegmentGroup4__SegmentGroup5__SegmentGroup9_SegmentGroup10> SegmentGroup10 {get;set;} = new();
	[SectionPosition(4)] public List<SegmentGroup4__SegmentGroup5__SegmentGroup9_SegmentGroup11> SegmentGroup11 {get;set;} = new();
	[SectionPosition(5)] public List<SegmentGroup4__SegmentGroup5__SegmentGroup9_SegmentGroup12> SegmentGroup12 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4__SegmentGroup5_SegmentGroup9>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.CollectionSize(x => x.HandlingInstructions, 1, 9);
		validator.CollectionSize(x => x.SegmentGroup10, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup11, 0, 99);
		validator.CollectionSize(x => x.SegmentGroup12, 0, 99);
		foreach (var item in SegmentGroup10) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup11) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in SegmentGroup12) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
