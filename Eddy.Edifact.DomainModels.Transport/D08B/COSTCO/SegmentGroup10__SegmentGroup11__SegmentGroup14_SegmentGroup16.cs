using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08B;

namespace Eddy.Edifact.DomainModels.Transport.D08B.COSTCO;

public class SegmentGroup10__SegmentGroup11__SegmentGroup14_SegmentGroup16 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup10__SegmentGroup11__SegmentGroup14_SegmentGroup16>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		return validator.Results;
	}
}
