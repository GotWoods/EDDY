using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99B;

namespace Eddy.Edifact.DomainModels.Transport.D99B.IFTSTQ;

public class SegmentGroup4__SegmentGroup6_SegmentGroup7 {
	[SectionPosition(1)] public GID_GoodsItemDetails GoodsItemDetails { get; set; } = new();
	[SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
	[SectionPosition(3)] public List<SGP_SplitGoodsPlacement> SplitGoodsPlacement { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4__SegmentGroup6_SegmentGroup7>(this);
		validator.Required(x => x.GoodsItemDetails);
		validator.Required(x => x.FreeText);
		validator.CollectionSize(x => x.SplitGoodsPlacement, 1, 99);
		return validator.Results;
	}
}
