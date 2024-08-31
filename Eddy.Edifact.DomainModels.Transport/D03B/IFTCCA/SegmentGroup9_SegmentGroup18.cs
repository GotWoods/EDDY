using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D03B;

namespace Eddy.Edifact.DomainModels.Transport.D03B.IFTCCA;

public class SegmentGroup9_SegmentGroup18 {
	[SectionPosition(1)] public TCC_ChargeRateCalculations ChargeRateCalculations { get; set; } = new();
	[SectionPosition(2)] public List<PRI_PriceDetails> PriceDetails { get; set; } = new();
	[SectionPosition(3)] public List<EQN_NumberOfUnits> NumberOfUnits { get; set; } = new();
	[SectionPosition(4)] public List<PCD_PercentageDetails> PercentageDetails { get; set; } = new();
	[SectionPosition(5)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(7)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(8)] public List<RFF_Reference> Reference { get; set; } = new();
	[SectionPosition(9)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(10)] public List<CUX_Currencies> Currencies { get; set; } = new();
	[SectionPosition(11)] public List<DTM_DateTimePeriod> DateTimePeriod { get; set; } = new();
	[SectionPosition(12)] public List<FTX_FreeText> FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9_SegmentGroup18>(this);
		validator.Required(x => x.ChargeRateCalculations);
		validator.CollectionSize(x => x.PriceDetails, 1, 9);
		validator.CollectionSize(x => x.NumberOfUnits, 1, 9);
		validator.CollectionSize(x => x.PercentageDetails, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		validator.CollectionSize(x => x.Quantity, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.Reference, 1, 9);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.CollectionSize(x => x.Currencies, 1, 9);
		validator.CollectionSize(x => x.DateTimePeriod, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		return validator.Results;
	}
}
