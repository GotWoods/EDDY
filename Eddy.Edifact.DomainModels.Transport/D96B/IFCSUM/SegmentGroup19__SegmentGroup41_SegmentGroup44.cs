using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B;

namespace Eddy.Edifact.DomainModels.Transport.D96B.IFCSUM;

public class SegmentGroup19__SegmentGroup41_SegmentGroup44 {
	[SectionPosition(1)] public DIM_Dimensions Dimensions { get; set; } = new();
	[SectionPosition(2)] public EQN_NumberOfUnits NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup19__SegmentGroup41_SegmentGroup44>(this);
		validator.Required(x => x.Dimensions);
		validator.Required(x => x.NumberOfUnits);
		return validator.Results;
	}
}
