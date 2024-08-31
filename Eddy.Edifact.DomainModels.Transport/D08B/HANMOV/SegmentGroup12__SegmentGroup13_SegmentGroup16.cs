using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08B;

namespace Eddy.Edifact.DomainModels.Transport.D08B.HANMOV;

public class SegmentGroup12__SegmentGroup13_SegmentGroup16 {
	[SectionPosition(1)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(2)] public List<QTY_Quantity> Quantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup12__SegmentGroup13_SegmentGroup16>(this);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		return validator.Results;
	}
}
