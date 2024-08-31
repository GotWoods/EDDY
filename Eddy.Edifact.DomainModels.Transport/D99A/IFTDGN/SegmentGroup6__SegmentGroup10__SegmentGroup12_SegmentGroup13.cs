using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;

namespace Eddy.Edifact.DomainModels.Transport.D99A.IFTDGN;

public class SegmentGroup6__SegmentGroup10__SegmentGroup12_SegmentGroup13 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public LOC_PlaceLocationIdentification PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6__SegmentGroup10__SegmentGroup12_SegmentGroup13>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.Required(x => x.PlaceLocationIdentification);
		validator.CollectionSize(x => x.Measurements, 1, 2);
		return validator.Results;
	}
}
