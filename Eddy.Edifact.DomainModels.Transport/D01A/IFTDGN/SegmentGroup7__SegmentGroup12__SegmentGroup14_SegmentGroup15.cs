using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01A;

namespace Eddy.Edifact.DomainModels.Transport.D01A.IFTDGN;

public class SegmentGroup7__SegmentGroup12__SegmentGroup14_SegmentGroup15 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup7__SegmentGroup12__SegmentGroup14_SegmentGroup15>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.Measurements, 1, 2);
		return validator.Results;
	}
}
