using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4060;

namespace Eddy.x12.DomainModels.Finance.v4060._155;

public class L20000__L23000__L23500_L23510 {
	[SectionPosition(1)] public LM_CodeSourceInformation CodeSourceInformation { get; set; } = new();
	[SectionPosition(2)] public List<III_Information> Information { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L20000__L23000__L23500_L23510>(this);
		validator.Required(x => x.CodeSourceInformation);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		return validator.Results;
	}
}
