using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._179;

public class LNM1_LQTY {
	[SectionPosition(1)] public QTY_QuantityInformation QuantityInformation { get; set; } = new();
	[SectionPosition(2)] public SPI_SpecificationIdentifier? SpecificationIdentifier { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNM1_LQTY>(this);
		validator.Required(x => x.QuantityInformation);
		return validator.Results;
	}
}
