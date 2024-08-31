using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D12B;

namespace Eddy.Edifact.DomainModels.Transport.D12B.TPFREP;

public class SegmentGroup2_SegmentGroup3 {
	[SectionPosition(1)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(3)] public List<QTY_Quantity> Quantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup2_SegmentGroup3>(this);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 99);
		return validator.Results;
	}
}
