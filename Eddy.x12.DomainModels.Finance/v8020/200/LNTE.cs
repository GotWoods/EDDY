using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8020;

namespace Eddy.x12.DomainModels.Finance.v8020._200;

public class LNTE {
	[SectionPosition(1)] public NTE_NoteSpecialInstruction NoteSpecialInstruction { get; set; } = new();
	[SectionPosition(2)] public List<TBI_TradeLineBureauIdentifier> TradeLineBureauIdentifier { get; set; } = new();
	[SectionPosition(3)] public List<MSG_MessageText> MessageText { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LNTE>(this);
		validator.Required(x => x.NoteSpecialInstruction);
		validator.CollectionSize(x => x.TradeLineBureauIdentifier, 0, 5);
		validator.CollectionSize(x => x.MessageText, 1, 2147483647);
		return validator.Results;
	}
}
