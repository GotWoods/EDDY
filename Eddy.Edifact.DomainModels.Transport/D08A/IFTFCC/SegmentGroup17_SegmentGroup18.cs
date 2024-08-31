using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08A;

namespace Eddy.Edifact.DomainModels.Transport.D08A.IFTFCC;

public class SegmentGroup17_SegmentGroup18 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup17_SegmentGroup18>(this);
		validator.Required(x => x.Reference);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
