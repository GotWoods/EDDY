using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._214;

public class L0200_L0230 {
	[SectionPosition(1)] public PRF_PurchaseOrderReference PurchaseOrderReference { get; set; } = new();
	[SectionPosition(2)] public List<L0200__L0230_L0231> L0231 {get;set;} = new();
	[SectionPosition(3)] public List<L0200__L0230_L0233> L0233 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0230>(this);
		validator.Required(x => x.PurchaseOrderReference);
		validator.CollectionSize(x => x.L0231, 0, 999999);
		validator.CollectionSize(x => x.L0233, 0, 999999);
		foreach (var item in L0231) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0233) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
