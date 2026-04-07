using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Finance.v3020._812;

public class LCDD {
	[SectionPosition(1)] public CDD_CreditDebitAdjustmentDetail CreditDebitAdjustmentDetail { get; set; } = new();
	[SectionPosition(2)] public LIN_ItemIdentification? ItemIdentification { get; set; }
	[SectionPosition(3)] public PO4_ItemPhysicalDetails? ItemPhysicalDetails { get; set; }
	[SectionPosition(4)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(5)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCDD>(this);
		validator.Required(x => x.CreditDebitAdjustmentDetail);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 1, 2147483647);
		validator.CollectionSize(x => x.ReferenceNumber, 1, 2147483647);
		return validator.Results;
	}
}
