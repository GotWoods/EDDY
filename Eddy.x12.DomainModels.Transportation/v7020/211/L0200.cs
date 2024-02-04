using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7020;

namespace Eddy.x12.DomainModels.Transportation.v7020._211;

public class L0200 {
	[SectionPosition(1)] public AT1_BillOfLadingLineItemNumber BillOfLadingLineItemNumber { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public AT3_BillOfLadingRatesAndCharges? BillOfLadingRatesAndCharges { get; set; }
	[SectionPosition(4)] public List<AT4_BillOfLadingDescription> BillOfLadingDescription { get; set; } = new();
	[SectionPosition(5)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(6)] public List<L0200_L0220> L0220 {get;set;} = new();
	[SectionPosition(7)] public List<L0200_L0230> L0230 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.BillOfLadingLineItemNumber);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 100);
		validator.CollectionSize(x => x.BillOfLadingDescription, 0, 99);
		validator.CollectionSize(x => x.L0220, 0, 999999);
		validator.CollectionSize(x => x.L0230, 0, 2);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0220) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0230) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
