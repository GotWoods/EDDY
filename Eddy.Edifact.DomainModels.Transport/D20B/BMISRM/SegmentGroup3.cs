using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20B;

namespace Eddy.Edifact.DomainModels.Transport.D20B.BMISRM;

public class SegmentGroup3 {
	[SectionPosition(1)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	[SectionPosition(2)] public STS_Status Status { get; set; } = new();
	[SectionPosition(3)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3>(this);
		validator.Required(x => x.DateTimePeriod);
		validator.Required(x => x.Status);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
