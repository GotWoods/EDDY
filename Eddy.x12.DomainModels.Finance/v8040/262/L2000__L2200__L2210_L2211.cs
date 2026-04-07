using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Finance.v8040._262;

public class L2000__L2200__L2210_L2211 {
	[SectionPosition(1)] public III_Information Information { get; set; } = new();
	[SectionPosition(2)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2200__L2210_L2211>(this);
		validator.Required(x => x.Information);
		validator.CollectionSize(x => x.MessageText, 0, 10);
		return validator.Results;
	}
}
