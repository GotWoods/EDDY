using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08B;

namespace Eddy.Edifact.DomainModels.Transport.D08B.IFCSUM;

public class SegmentGroup9__SegmentGroup17_SegmentGroup19 {
	[SectionPosition(1)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9__SegmentGroup17_SegmentGroup19>(this);
		validator.Required(x => x.DocumentMessageDetails);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
