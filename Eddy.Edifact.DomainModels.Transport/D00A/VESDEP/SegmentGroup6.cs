using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A;

namespace Eddy.Edifact.DomainModels.Transport.D00A.VESDEP;

public class SegmentGroup6 {
	[SectionPosition(1)] public QTY_Quantity Quantity { get; set; } = new();
	[SectionPosition(2)] public FTX_FreeText FreeText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<SegmentGroup6>(this);
		validator.Required(x => x.Quantity);
		validator.Required(x => x.FreeText);
		return validator.Results;
	}
}
