using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Finance.v3050._262;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<PEX_PropertyOrHousingExpense> PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(3)] public List<PDS_PropertyDescriptionLegalDescription> PropertyDescriptionLegalDescription { get; set; } = new();
	[SectionPosition(4)] public List<PDE_PropertyMetesAndBoundsDescription> PropertyMetesAndBoundsDescription { get; set; } = new();
	[SectionPosition(5)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(6)] public List<QTY_Quantity> Quantity { get; set; } = new();
	[SectionPosition(7)] public List<LLX_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(8)] public List<LLX_LIN1> LIN1 {get;set;} = new();
	[SectionPosition(9)] public List<LLX_LLQ> LLQ {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.PropertyOrHousingExpense, 1, 3);
		validator.CollectionSize(x => x.PropertyDescriptionLegalDescription, 0, 10);
		validator.CollectionSize(x => x.PropertyMetesAndBoundsDescription, 0, 50);
		validator.CollectionSize(x => x.PercentAmounts, 0, 8);
		validator.CollectionSize(x => x.Quantity, 0, 15);
		validator.CollectionSize(x => x.LNX1, 1, 15);
		validator.CollectionSize(x => x.LIN1, 1, 6);
		validator.CollectionSize(x => x.LLQ, 1, 2147483647);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LLQ) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
