using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4050;

namespace Eddy.x12.DomainModels.Transportation.v4050._160;

public class LEI__LTSI_LQTY {
	[SectionPosition(1)] public QTY_Quantity QuantityInformation { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LEI__LTSI_LQTY>(this);
		validator.Required(x => x.QuantityInformation);
		validator.CollectionSize(x => x.DateTimeReference, 0, 2);
		return validator.Results;
	}
}