using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17B;

namespace Eddy.Edifact.DomainModels.Transport.D17B.IFTFCC;

public class SegmentGroup28__SegmentGroup37_SegmentGroup40 {
	[SectionPosition(1)] public RFF_Reference Reference { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimePeriod DateTimePeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28__SegmentGroup37_SegmentGroup40>(this);
		validator.Required(x => x.Reference);
		validator.Required(x => x.DateTimePeriod);
		return validator.Results;
	}
}
