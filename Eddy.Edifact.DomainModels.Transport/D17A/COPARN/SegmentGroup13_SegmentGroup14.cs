using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D17A;

namespace Eddy.Edifact.DomainModels.Transport.D17A.COPARN;

public class SegmentGroup13_SegmentGroup14 {
	[SectionPosition(1)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(2)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup13_SegmentGroup14>(this);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.RangeDetails);
		return validator.Results;
	}
}
