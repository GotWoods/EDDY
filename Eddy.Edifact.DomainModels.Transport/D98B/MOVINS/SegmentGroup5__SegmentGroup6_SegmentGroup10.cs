using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B;

namespace Eddy.Edifact.DomainModels.Transport.D98B.MOVINS;

public class SegmentGroup5__SegmentGroup6_SegmentGroup10 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public GDS_NatureOfCargo NatureOfCargo { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5__SegmentGroup6_SegmentGroup10>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.Required(x => x.NatureOfCargo);
		return validator.Results;
	}
}
