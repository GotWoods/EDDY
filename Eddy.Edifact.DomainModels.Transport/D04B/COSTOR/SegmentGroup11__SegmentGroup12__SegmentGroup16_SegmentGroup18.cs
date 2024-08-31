using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04B;

namespace Eddy.Edifact.DomainModels.Transport.D04B.COSTOR;

public class SegmentGroup11__SegmentGroup12__SegmentGroup16_SegmentGroup18 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup11__SegmentGroup12__SegmentGroup16_SegmentGroup18>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		return validator.Results;
	}
}
