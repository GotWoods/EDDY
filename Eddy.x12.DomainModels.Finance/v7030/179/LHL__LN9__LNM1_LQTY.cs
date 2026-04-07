using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Finance.v7030._179;

public class LHL__LN9__LNM1_LQTY {
	[SectionPosition(1)] public QTY_QuantityInformation QuantityInformation { get; set; } = new();
	[SectionPosition(2)] public List<III_Information> Information { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LN9__LNM1_LQTY>(this);
		validator.Required(x => x.QuantityInformation);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		return validator.Results;
	}
}
