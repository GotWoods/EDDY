using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D08B;

namespace Eddy.Edifact.DomainModels.Transport.D08B.IFTCCA;

public class SegmentGroup9__SegmentGroup19_SegmentGroup20 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9__SegmentGroup19_SegmentGroup20>(this);
		validator.Required(x => x.Measurements);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
