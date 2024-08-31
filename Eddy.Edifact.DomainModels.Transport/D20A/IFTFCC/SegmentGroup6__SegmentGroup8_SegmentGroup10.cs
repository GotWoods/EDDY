using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D20A;

namespace Eddy.Edifact.DomainModels.Transport.D20A.IFTFCC;

public class SegmentGroup6__SegmentGroup8_SegmentGroup10 {
	[SectionPosition(1)] public TAX_DutyTaxFeeDetails DutyTaxFeeDetails { get; set; } = new();
	[SectionPosition(2)] public PCD_PercentageDetails PercentageDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6__SegmentGroup8_SegmentGroup10>(this);
		validator.Required(x => x.DutyTaxFeeDetails);
		validator.Required(x => x.PercentageDetails);
		return validator.Results;
	}
}
