using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D14B;

namespace Eddy.Edifact.DomainModels.Transport.D14B.COPARN;

public class SegmentGroup6_SegmentGroup9 {
	[SectionPosition(1)] public SGP_SplitGoodsPlacement SplitGoodsPlacement { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup9>(this);
		validator.Required(x => x.SplitGoodsPlacement);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		return validator.Results;
	}
}
