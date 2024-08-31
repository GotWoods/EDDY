using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D06B;

namespace Eddy.Edifact.DomainModels.Transport.D06B.COSTOR;

public class SegmentGroup11__SegmentGroup12_SegmentGroup13 {
	[SectionPosition(1)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(2)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup11__SegmentGroup12_SegmentGroup13>(this);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.RangeDetails);
		return validator.Results;
	}
}
