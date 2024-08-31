using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D10B;

namespace Eddy.Edifact.DomainModels.Transport.D10B.CALINF;

public class SegmentGroup1 {
	[SectionPosition(1)] public FTX_FreeText FreeText { get; set; } = new();
	[SectionPosition(2)] public List<MEA_Measurements> Measurements { get; set; } = new();
	[SectionPosition(3)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup1>(this);
		validator.Required(x => x.FreeText);
		validator.CollectionSize(x => x.Measurements, 1, 9);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
