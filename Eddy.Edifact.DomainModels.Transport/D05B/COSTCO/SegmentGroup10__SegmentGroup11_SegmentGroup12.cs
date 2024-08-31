using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D05B;

namespace Eddy.Edifact.DomainModels.Transport.D05B.COSTCO;

public class SegmentGroup10__SegmentGroup11_SegmentGroup12 {
	[SectionPosition(1)] public TMP_Temperature Temperature { get; set; } = new();
	[SectionPosition(2)] public RNG_RangeDetails RangeDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup10__SegmentGroup11_SegmentGroup12>(this);
		validator.Required(x => x.Temperature);
		validator.Required(x => x.RangeDetails);
		return validator.Results;
	}
}
