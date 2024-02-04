using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._309;

public class LP4 {
	[SectionPosition(1)] public P4_PortOfDischargeInformation PortOfDischargeInformation { get; set; } = new();
	[SectionPosition(2)] public LS_LoopHeader LoopHeader { get; set; } = new();
	[SectionPosition(3)] public List<LP4_LLX> LLX {get;set;} = new();
	[SectionPosition(4)] public LE_LoopTrailer LoopTrailer { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LP4>(this);
		validator.Required(x => x.PortOfDischargeInformation);
		validator.Required(x => x.LoopHeader);
		validator.Required(x => x.LoopTrailer);
		validator.CollectionSize(x => x.LLX, 1, 9999);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
