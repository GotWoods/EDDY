using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.IFTCCA;

public class SegmentGroup3 {
	[SectionPosition(1)] public CPI_ChargePaymentInstructions ChargePaymentInstructions { get; set; } = new();
	[SectionPosition(2)] public List<CUX_Currencies> Currencies { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup3>(this);
		validator.Required(x => x.ChargePaymentInstructions);
		validator.CollectionSize(x => x.Currencies, 1, 9);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		return validator.Results;
	}
}
