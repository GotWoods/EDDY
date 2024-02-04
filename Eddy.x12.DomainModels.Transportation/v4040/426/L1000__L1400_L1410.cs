using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._426;

public class L1000__L1400_L1410 {
	[SectionPosition(1)] public R2B_JunctionsAndProportions JunctionsAndProportions { get; set; } = new();
	[SectionPosition(2)] public List<R2C_DivisionBasis> DivisionBasis { get; set; } = new();
	[SectionPosition(3)] public List<R2D_MiscellaneousCharge> MiscellaneousCharge { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L1000__L1400_L1410>(this);
		validator.Required(x => x.JunctionsAndProportions);
		validator.CollectionSize(x => x.DivisionBasis, 0, 20);
		validator.CollectionSize(x => x.MiscellaneousCharge, 0, 5);
		return validator.Results;
	}
}
