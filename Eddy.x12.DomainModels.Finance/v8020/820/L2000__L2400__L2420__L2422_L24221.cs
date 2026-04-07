using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._820;

public class L2000__L2400__L2420__L2422_L24221 {
	[SectionPosition(1)] public REF_ReferenceInformation ReferenceInformation { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2400__L2420__L2422_L24221>(this);
		validator.Required(x => x.ReferenceInformation);
		return validator.Results;
	}
}
