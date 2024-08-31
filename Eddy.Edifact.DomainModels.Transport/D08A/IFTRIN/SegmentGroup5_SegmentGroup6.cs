using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08A;

namespace Eddy.Edifact.DomainModels.Transport.D08A.IFTRIN;

public class SegmentGroup5_SegmentGroup6 {
	[SectionPosition(1)] public TCC_ChargeRateCalculations ChargeRateCalculations { get; set; } = new();
	[SectionPosition(2)] public List<EQN_NumberOfUnits> NumberOfUnits { get; set; } = new();
	[SectionPosition(3)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(4)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(5)] public List<PRI_PriceDetails> PriceDetails { get; set; } = new();
	[SectionPosition(6)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup5_SegmentGroup6>(this);
		validator.Required(x => x.ChargeRateCalculations);
		validator.CollectionSize(x => x.NumberOfUnits, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		validator.CollectionSize(x => x.PriceDetails, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		return validator.Results;
	}
}
