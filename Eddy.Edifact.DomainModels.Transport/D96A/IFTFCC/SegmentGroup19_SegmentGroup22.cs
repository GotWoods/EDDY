using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFTFCC;

public class SegmentGroup19_SegmentGroup22 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19_SegmentGroup22>(this);
		validator.Required(x => x.Reference);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
