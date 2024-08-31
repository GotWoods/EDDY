using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D11A;

namespace Eddy.Edifact.DomainModels.Transport.D11A.HANMOV;

public class SegmentGroup1 {
	[SectionPosition(1)] public TCC_ChargeRateCalculations ChargeRateCalculations { get; set; } = new();
	[SectionPosition(2)] public List<LOC_PlaceLocationIdentification> PlaceLocationIdentification { get; set; } = new();
	[SectionPosition(3)] public List<FTX_FreeText> FreeText { get; set; } = new();
	[SectionPosition(4)] public List<CUX_Currencies> Currencies { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup1>(this);
		validator.Required(x => x.ChargeRateCalculations);
		validator.CollectionSize(x => x.PlaceLocationIdentification, 1, 9);
		validator.CollectionSize(x => x.FreeText, 1, 9);
		validator.CollectionSize(x => x.Currencies, 1, 9);
		return validator.Results;
	}
}
