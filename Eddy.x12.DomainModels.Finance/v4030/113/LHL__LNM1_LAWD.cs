using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4030;

namespace Eddy.x12.DomainModels.Finance.v4030._113;

public class LHL__LNM1_LAWD {
	[SectionPosition(1)] public AWD_AmountWithDescription AmountWithDescription { get; set; } = new();
	[SectionPosition(2)] public List<DTM_DateTimeReference> DateTimeReference { get; set; } = new();
	[SectionPosition(3)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(4)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(5)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public List<PDL_PaymentDetails> PaymentDetails { get; set; } = new();
	[SectionPosition(7)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	[SectionPosition(8)] public List<N1_Name> Name { get; set; } = new();
	[SectionPosition(9)] public List<MTX_Text> Text { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL__LNM1_LAWD>(this);
		validator.Required(x => x.AmountWithDescription);
		validator.CollectionSize(x => x.DateTimeReference, 1, 2147483647);
		validator.CollectionSize(x => x.PercentAmounts, 1, 2147483647);
		validator.CollectionSize(x => x.Quantity, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 2147483647);
		validator.CollectionSize(x => x.PaymentDetails, 1, 2147483647);
		validator.CollectionSize(x => x.IndustryCode, 1, 2147483647);
		validator.CollectionSize(x => x.Name, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		return validator.Results;
	}
}
