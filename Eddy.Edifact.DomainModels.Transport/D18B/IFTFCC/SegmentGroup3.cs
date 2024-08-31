using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D18B;

namespace Eddy.Edifact.DomainModels.Transport.D18B.IFTFCC;

public class SegmentGroup3 {
	[SectionPosition(1)] public MOA_MonetaryAmount MonetaryAmount { get; set; } = new();
	[SectionPosition(2)] public PCD_PercentageDetails PercentageDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3>(this);
		validator.Required(x => x.MonetaryAmount);
		validator.Required(x => x.PercentageDetails);
		return validator.Results;
	}
}
