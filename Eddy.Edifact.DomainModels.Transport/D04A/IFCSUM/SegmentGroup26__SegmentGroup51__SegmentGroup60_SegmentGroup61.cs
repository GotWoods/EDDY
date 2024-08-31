using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D04A;

namespace Eddy.Edifact.DomainModels.Transport.D04A.IFCSUM;

public class SegmentGroup26__SegmentGroup51__SegmentGroup60_SegmentGroup61 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup26__SegmentGroup51__SegmentGroup60_SegmentGroup61>(this);
		validator.Required(x => x.Measurements);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
