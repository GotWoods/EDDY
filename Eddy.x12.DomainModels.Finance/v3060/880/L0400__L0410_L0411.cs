using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._880;

public class L0400__L0410_L0411 {
	[SectionPosition(1)] public G17_ItemDetailInvoice ItemDetailInvoice { get; set; } = new();
	[SectionPosition(2)] public List<G19_LineItemDetailQuantityUnitOfMeasurePriceDifferences> LineItemDetailQuantityUnitOfMeasurePriceDifferences { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400__L0410_L0411>(this);
		validator.Required(x => x.ItemDetailInvoice);
		validator.CollectionSize(x => x.LineItemDetailQuantityUnitOfMeasurePriceDifferences, 0, 10);
		return validator.Results;
	}
}
