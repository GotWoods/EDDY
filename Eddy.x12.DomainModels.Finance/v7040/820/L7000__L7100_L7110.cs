using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7040;

namespace Eddy.x12.DomainModels.Finance.v7040._820;

public class L7000__L7100_L7110 {
	[SectionPosition(1)] public LOC_Location Location { get; set; } = new();
	[SectionPosition(2)] public List<L7000__L7100__L7110_L7111> L7111 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L7000__L7100_L7110>(this);
		validator.Required(x => x.Location);
		validator.CollectionSize(x => x.L7111, 1, 2147483647);
		foreach (var item in L7111) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
