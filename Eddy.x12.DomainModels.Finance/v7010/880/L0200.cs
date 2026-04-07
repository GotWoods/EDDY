using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._880;

public class L0200 {
	[SectionPosition(1)] public G72_AllowanceOrCharge AllowanceOrCharge { get; set; } = new();
	[SectionPosition(2)] public List<G73_AllowanceOrChargeDescription> AllowanceOrChargeDescription { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.AllowanceOrCharge);
		validator.CollectionSize(x => x.AllowanceOrChargeDescription, 0, 10);
		return validator.Results;
	}
}
