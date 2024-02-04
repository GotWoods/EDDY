using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Transportation.v4020._223;

public class L4000 {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<CSD_ConsolidatedShipmentInvoiceData> ConsolidatedShipmentInvoiceData { get; set; } = new();
	[SectionPosition(3)] public List<L4000_L4100> L4100 {get;set;} = new();
	[SectionPosition(4)] public List<L4000_L4500> L4500 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L4000>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ConsolidatedShipmentInvoiceData, 1, 5);
		validator.CollectionSize(x => x.L4100, 0, 9999);
		validator.CollectionSize(x => x.L4500, 0, 999);
		foreach (var item in L4100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L4500) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
