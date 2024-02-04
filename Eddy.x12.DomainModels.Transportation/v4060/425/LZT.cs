using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Transportation.v4060._425;

public class LZT {
	[SectionPosition(1)] public ZT_WaybillRequestInformation WaybillRequestInformation { get; set; } = new();
	[SectionPosition(2)] public F9_OriginStation? OriginStation { get; set; }
	[SectionPosition(3)] public D9_DestinationStation? DestinationStation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LZT>(this);
		validator.Required(x => x.WaybillRequestInformation);
		return validator.Results;
	}
}
