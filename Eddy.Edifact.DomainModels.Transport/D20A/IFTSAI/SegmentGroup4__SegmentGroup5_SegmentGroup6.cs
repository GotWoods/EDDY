using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20A;

namespace Eddy.Edifact.DomainModels.Transport.D20A.IFTSAI;

public class SegmentGroup4__SegmentGroup5_SegmentGroup6 {
	[SectionPosition(1)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4__SegmentGroup5_SegmentGroup6>(this);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
