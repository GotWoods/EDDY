using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7050;

namespace Eddy.x12.DomainModels.Transportation.v7050._219;

public class L2000 {
	[SectionPosition(1)] public S5_StopOffDetails StopOffDetails { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(5)] public List<L2000_L2100> L2100 {get;set;} = new();
	[SectionPosition(6)] public List<L2000_L2200> L2200 {get;set;} = new();
	[SectionPosition(7)] public List<L2000_L2300> L2300 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000>(this);
		validator.Required(x => x.StopOffDetails);
		validator.CollectionSize(x => x.DateTime, 0, 3);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 1, 2147483647);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 20);
		validator.CollectionSize(x => x.L2100, 0, 10);
		validator.CollectionSize(x => x.L2200, 0, 99);
		validator.CollectionSize(x => x.L2300, 1, 2147483647);
		foreach (var item in L2100) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2200) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L2300) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
