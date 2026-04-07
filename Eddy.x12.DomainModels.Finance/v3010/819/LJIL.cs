using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3010;

namespace Eddy.x12.DomainModels.Finance.v3010._819;

public class LJIL {
	[SectionPosition(1)] public JIL_LineItemDetailForTheOperatingExpenseStatement LineItemDetailForTheOperatingExpenseStatement { get; set; } = new();
	[SectionPosition(2)] public List<PID_ProductItemDescription> ProductItemDescription { get; set; } = new();
	[SectionPosition(3)] public List<REF_ReferenceNumbers> ReferenceNumbers { get; set; } = new();
	[SectionPosition(4)] public List<LJIL_LJID> LJID {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LJIL>(this);
		validator.Required(x => x.LineItemDetailForTheOperatingExpenseStatement);
		validator.CollectionSize(x => x.ProductItemDescription, 0, 99);
		validator.CollectionSize(x => x.ReferenceNumbers, 0, 12);
		validator.CollectionSize(x => x.LJID, 0, 1000);
		foreach (var item in LJID) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
