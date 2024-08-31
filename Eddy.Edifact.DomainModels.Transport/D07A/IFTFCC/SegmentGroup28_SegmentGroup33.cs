using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07A;

namespace Eddy.Edifact.DomainModels.Transport.D07A.IFTFCC;

public class SegmentGroup28_SegmentGroup33 {
	[SectionPosition(1)] public CPI_ChargePaymentInstructions ChargePaymentInstructions { get; set; } = new();
	[SectionPosition(2)] public CUX_Currencies Currencies { get; set; } = new();
	[SectionPosition(3)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(4)] public List<MOA_MonetaryAmount> MonetaryAmount { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup28_SegmentGroup33>(this);
		validator.Required(x => x.ChargePaymentInstructions);
		validator.Required(x => x.Currencies);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.MonetaryAmount, 1, 9);
		return validator.Results;
	}
}
