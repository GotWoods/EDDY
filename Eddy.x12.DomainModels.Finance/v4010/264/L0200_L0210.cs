using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Finance.v4010._264;

public class L0200_L0210 {
	[SectionPosition(1)] public DTP_DateOrTimeOrPeriod DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(2)] public List<REF_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<L0200__L0210_L0211> L0211 {get;set;} = new();
	[SectionPosition(4)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(5)] public List<L0200__L0210_L0212> L0212 {get;set;} = new();
	[SectionPosition(6)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200_L0210>(this);
		validator.Required(x => x.DateOrTimeOrPeriod);
		validator.CollectionSize(x => x.ReferenceIdentification, 1, 10);
		validator.CollectionSize(x => x.L0211, 1, 2147483647);
		foreach (var item in L0211) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0212) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
