using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D07A;

namespace Eddy.Edifact.DomainModels.Transport.D07A.CODECO;

public class SegmentGroup10_SegmentGroup11 {
	[SectionPosition(1)] public DAM_Damage Damage { get; set; } = new();
	[SectionPosition(2)] public COD_ComponentDetails ComponentDetails { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup10_SegmentGroup11>(this);
		validator.Required(x => x.Damage);
		validator.Required(x => x.ComponentDetails);
		return validator.Results;
	}
}
