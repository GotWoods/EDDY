using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04B;

namespace Eddy.Edifact.DomainModels.Transport.D04B.TPFREP;

public class SegmentGroup2_SegmentGroup3 {
	[SectionPosition(1)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(2)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup2_SegmentGroup3>(this);
		validator.Required(x => x.DateTimePeriod);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
