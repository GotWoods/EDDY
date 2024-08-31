using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17A;

namespace Eddy.Edifact.DomainModels.Transport.D17A.IFTCCA;

public class SegmentGroup9__SegmentGroup16_SegmentGroup17 {
	[SectionPosition(1)] public MEA_Measurements Measurements { get; set; } = new();
	[SectionPosition(2)] public List<EQN_NumberOfUnits> NumberOfUnits { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup9__SegmentGroup16_SegmentGroup17>(this);
		validator.Required(x => x.Measurements);
		validator.CollectionSize(x => x.NumberOfUnits, 1, 9);
		return validator.Results;
	}
}
