using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._113;

public class LAWD {
	[SectionPosition(1)] public AWD_AmountWithDescription AmountWithDescription { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCodeIdentification> IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(3)] public List<MTX_Text> Text { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LAWD>(this);
		validator.Required(x => x.AmountWithDescription);
		validator.CollectionSize(x => x.IndustryCodeIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		return validator.Results;
	}
}
