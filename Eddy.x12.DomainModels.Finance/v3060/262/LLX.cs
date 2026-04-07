using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Finance.v3060._262;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<AM1_InformationalValues> InformationalValues { get; set; } = new();
	[SectionPosition(3)] public List<PWK_Paperwork> Paperwork { get; set; } = new();
	[SectionPosition(4)] public List<LLX_LNX1> LNX1 {get;set;} = new();
	[SectionPosition(5)] public List<LLX_LIN1> LIN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.InformationalValues, 0, 4);
		validator.CollectionSize(x => x.Paperwork, 0, 5);
		validator.CollectionSize(x => x.LNX1, 1, 2147483647);
		validator.CollectionSize(x => x.LIN1, 1, 6);
		foreach (var item in LNX1) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
