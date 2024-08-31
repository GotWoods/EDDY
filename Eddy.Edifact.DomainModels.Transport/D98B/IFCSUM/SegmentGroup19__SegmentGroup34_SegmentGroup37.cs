using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D98B;

namespace Eddy.Edifact.DomainModels.Transport.D98B.IFCSUM;

public class SegmentGroup19__SegmentGroup34_SegmentGroup37 {
	[SectionPosition(1)] public TCC_TransportChargeRateCalculations TransportChargeRateCalculations { get; set; } = new();
	[SectionPosition(2)] public CUX_Currencies Currencies { get; set; } = new();
	[SectionPosition(3)] public PRI_PriceDetails PriceDetails { get; set; } = new();
	[SectionPosition(4)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	[SectionPosition(5)] public PCD_PercentageDetails PercentageDetails { get; set; } = new();
	[SectionPosition(6)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(7)] public List<QTY_Quantity> Quantity { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup34_SegmentGroup37>(this);
		validator.Required(x => x.TransportChargeRateCalculations);
		validator.Required(x => x.Currencies);
		validator.Required(x => x.PriceDetails);
		validator.Required(x => x.NumberOfUnits);
		validator.Required(x => x.PercentageDetails);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		return validator.Results;
	}
}
