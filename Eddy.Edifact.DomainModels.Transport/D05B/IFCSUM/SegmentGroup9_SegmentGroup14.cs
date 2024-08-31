using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.IFCSUM;

public class SegmentGroup9_SegmentGroup14 {
	[SectionPosition(1)] public TCC_ChargeRateCalculations ChargeRateCalculations { get; set; } = new();
	[SectionPosition(2)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(3)] public PCD_PercentageDetails PercentageDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9_SegmentGroup14>(this);
		validator.Required(x => x.ChargeRateCalculations);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.Required(x => x.PercentageDetails);
		return validator.Results;
	}
}
