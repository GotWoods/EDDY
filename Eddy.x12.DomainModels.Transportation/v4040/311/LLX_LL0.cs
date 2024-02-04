using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Transportation.v4040._311;

public class LLX_LL0 {
	[SectionPosition(1)] public L0_LineItemQuantityAndWeight LineItemQuantityAndWeight { get; set; } = new();
	[SectionPosition(2)] public List<L5_DescriptionMarksAndNumbers> DescriptionMarksAndNumbers { get; set; } = new();
	[SectionPosition(3)] public L4_Measurement? Measurement { get; set; }
	[SectionPosition(4)] public List<X1_ExportLicense> ExportLicense { get; set; } = new();
	[SectionPosition(5)] public List<X2_ImportLicense> ImportLicense { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LL0>(this);
		validator.Required(x => x.LineItemQuantityAndWeight);
		validator.CollectionSize(x => x.DescriptionMarksAndNumbers, 1, 999);
		validator.CollectionSize(x => x.ExportLicense, 0, 5);
		validator.CollectionSize(x => x.ImportLicense, 0, 5);
		return validator.Results;
	}
}
