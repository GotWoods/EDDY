using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._419;

public class LE6 {
	[SectionPosition(1)] public E6_AdvanceCarDisposition AdvanceCarDisposition { get; set; } = new();
	[SectionPosition(2)] public W3_ConsigneeInformation? ConsigneeInformation { get; set; }
	[SectionPosition(3)] public W5_RouteInformation? RouteInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LE6>(this);
		validator.Required(x => x.AdvanceCarDisposition);
		return validator.Results;
	}
}
