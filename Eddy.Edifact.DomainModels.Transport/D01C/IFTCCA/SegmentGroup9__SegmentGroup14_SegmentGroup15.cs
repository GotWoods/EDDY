using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D01C;

namespace Eddy.Edifact.DomainModels.Transport.D01C.IFTCCA;

public class SegmentGroup9__SegmentGroup14_SegmentGroup15 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public List<EQN_NumberOfUnits> NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9__SegmentGroup14_SegmentGroup15>(this);
		validator.Required(x => x.Measurements);
		validator.CollectionSize(x => x.NumberOfUnits, 1, 9);
		return validator.Results;
	}
}
