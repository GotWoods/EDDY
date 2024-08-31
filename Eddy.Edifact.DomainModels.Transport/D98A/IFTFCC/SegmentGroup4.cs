using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98A;

namespace Eddy.Edifact.DomainModels.Transport.D98A.IFTFCC;

public class SegmentGroup4 {
	[SectionPosition(1)] public TAX_DutyTaxFeeDetails DutyTaxFeeDetails { get; set; } = new();
	[SectionPosition(2)] public PCD_PercentageDetails PercentageDetails { get; set; } = new();
	[SectionPosition(3)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup4>(this);
		validator.Required(x => x.DutyTaxFeeDetails);
		validator.Required(x => x.PercentageDetails);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 2);
		return validator.Results;
	}
}
