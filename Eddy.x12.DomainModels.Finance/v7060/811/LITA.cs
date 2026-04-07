using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Finance.v7060._811;

public class LITA {
	[SectionPosition(1)] public ITA_AllowanceChargeOrService AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(2)] public DTM_DateTimeReference? DateTimeReference { get; set; }
	[SectionPosition(3)] public List<REF_ReferenceInformation> ReferenceInformation { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LITA>(this);
		validator.Required(x => x.AllowanceChargeOrService);
		validator.CollectionSize(x => x.ReferenceInformation, 0, 5);
		return validator.Results;
	}
}
