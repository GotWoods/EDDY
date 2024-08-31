using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A;

namespace Eddy.Edifact.DomainModels.Transport.D96A.IFCSUM;

public class SegmentGroup25__SegmentGroup38_SegmentGroup41 {
	[SectionPosition(1)] public TCC_TransportChargeRateCalculations TransportChargeRateCalculations { get; set; } = new();
	[SectionPosition(2)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(3)] public PCD_PercentageDetails PercentageDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup38_SegmentGroup41>(this);
		validator.Required(x => x.TransportChargeRateCalculations);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.Required(x => x.PercentageDetails);
		return validator.Results;
	}
}
