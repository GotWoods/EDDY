using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A;

namespace Eddy.Edifact.DomainModels.Transport.D99A.IFCSUM;

public class SegmentGroup19__SegmentGroup34_SegmentGroup36 {
	[SectionPosition(1)] public DOC_DocumentMessageDetails DocumentMessageDetails { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup34_SegmentGroup36>(this);
		validator.Required(x => x.DocumentMessageDetails);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
