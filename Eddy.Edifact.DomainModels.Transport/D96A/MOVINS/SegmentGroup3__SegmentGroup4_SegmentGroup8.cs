using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.MOVINS;

public class SegmentGroup3__SegmentGroup4_SegmentGroup8 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public GDS_NatureOfCargo NatureOfCargo { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3__SegmentGroup4_SegmentGroup8>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.Required(x => x.NatureOfCargo);
		return validator.Results;
	}
}
