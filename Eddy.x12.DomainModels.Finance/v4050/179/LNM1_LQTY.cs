using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Finance.v4050._179;

public class LNM1_LQTY {
	[SectionPosition(1)] public QTY_Quantity QuantityInformation { get; set; } = new();
	[SectionPosition(2)] public SPI_SpecificationIdentifier? SpecificationIdentifier { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LQTY>(this);
		validator.Required(x => x.QuantityInformation);
		return validator.Results;
	}
}
