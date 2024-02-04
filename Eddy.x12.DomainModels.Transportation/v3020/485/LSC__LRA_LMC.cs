using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._485;

public class LSC__LRA_LMC {
	[SectionPosition(1)] public MC_MiscellaneousAndAccessorialCharges MiscellaneousAndAccessorialCharges { get; set; } = new();
	[SectionPosition(2)] public List<FK_Factor> Factor { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSC__LRA_LMC>(this);
		validator.Required(x => x.MiscellaneousAndAccessorialCharges);
		validator.CollectionSize(x => x.Factor, 0, 5);
		return validator.Results;
	}
}
