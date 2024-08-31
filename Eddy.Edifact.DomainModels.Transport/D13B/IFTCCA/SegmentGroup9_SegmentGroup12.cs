using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D13B;

namespace Eddy.Edifact.DomainModels.Transport.D13B.IFTCCA;

public class SegmentGroup9_SegmentGroup12 {
	[SectionPosition(1)] public DIM_Dimensions Dimensions { get; set; } = new();
	[SectionPosition(2)] public List<EQN_NumberOfUnits> NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9_SegmentGroup12>(this);
		validator.Required(x => x.Dimensions);
		validator.CollectionSize(x => x.NumberOfUnits, 1, 9);
		return validator.Results;
	}
}
