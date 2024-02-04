using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._858;

public class LS5 {
	[SectionPosition(1)] public S5_StopOffDetails StopOffDetails { get; set; } = new();
	[SectionPosition(2)] public List<G62_DateTime> DateTime { get; set; } = new();
	[SectionPosition(3)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(4)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(5)] public List<LS5_LN1> LN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LS5>(this);
		validator.Required(x => x.StopOffDetails);
		validator.CollectionSize(x => x.DateTime, 0, 6);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		validator.CollectionSize(x => x.SpecialServices, 0, 6);
		validator.CollectionSize(x => x.LN1, 0, 5);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
