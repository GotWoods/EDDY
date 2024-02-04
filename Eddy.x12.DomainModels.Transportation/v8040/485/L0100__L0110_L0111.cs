using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8040;

namespace Eddy.x12.DomainModels.Transportation.v8040._485;

public class L0100__L0110_L0111 {
	[SectionPosition(1)] public MC_MiscellaneousAndAccessorialCharges MiscellaneousAndAccessorialCharges { get; set; } = new();
	[SectionPosition(2)] public List<FK_Factor> Factor { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100__L0110_L0111>(this);
		validator.Required(x => x.MiscellaneousAndAccessorialCharges);
		validator.CollectionSize(x => x.Factor, 0, 5);
		return validator.Results;
	}
}
