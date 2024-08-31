using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00B;

namespace Eddy.Edifact.DomainModels.Transport.D00B.IFCSUM;

public class SegmentGroup25__SegmentGroup50__SegmentGroup59_SegmentGroup60 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup25__SegmentGroup50__SegmentGroup59_SegmentGroup60>(this);
		validator.Required(x => x.Measurements);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
