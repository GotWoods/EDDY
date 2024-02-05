using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030;

namespace Eddy.x12.DomainModels.CommunicationsAndControls.v6030._864;

public class LMIT {
	[SectionPosition(1)] public MIT_MessageIdentification MessageIdentification { get; set; } = new();
	[SectionPosition(2)] public List<LMIT_LN1> LN1 {get;set;} = new();
	[SectionPosition(3)] public List<MSG_MessageText> MessageText { get; set; } = new();
	[SectionPosition(4)] public List<MTX_Text> Text { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LMIT>(this);
		validator.Required(x => x.MessageIdentification);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		validator.CollectionSize(x => x.Text, 1, 2147483647);
		validator.CollectionSize(x => x.LN1, 0, 200);
		foreach (var item in LN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
