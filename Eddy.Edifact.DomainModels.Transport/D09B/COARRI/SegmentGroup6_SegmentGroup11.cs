using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D09B;

namespace Eddy.Edifact.DomainModels.Transport.D09B.COARRI;

public class SegmentGroup6_SegmentGroup11 {
	[SectionPosition(1)] public DAM_Damage Damage { get; set; } = new();
	[SectionPosition(2)] public COD_ComponentDetails ComponentDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6_SegmentGroup11>(this);
		validator.Required(x => x.Damage);
		validator.Required(x => x.ComponentDetails);
		return validator.Results;
	}
}
