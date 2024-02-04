using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.Transportation.v6030._108;

public class L0200 {
	[SectionPosition(1)] public CA1_RateRequestIdentifier RateRequestIdentifier { get; set; } = new();
	[SectionPosition(2)] public LC1_LaneCommitments LaneCommitments { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.RateRequestIdentifier);
		validator.Required(x => x.LaneCommitments);
		return validator.Results;
	}
}
