using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._194;

public class LHL_LPO1 {
	[SectionPosition(1)] public PO1_BaselineItemData BaselineItemData { get; set; } = new();
	[SectionPosition(2)] public List<MTX_Text> Text { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LPO1>(this);
		validator.Required(x => x.BaselineItemData);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		return validator.Results;
	}
}
