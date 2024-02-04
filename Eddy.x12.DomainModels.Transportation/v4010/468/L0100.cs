using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4010;

namespace Eddy.x12.DomainModels.Transportation.v4010._468;

public class L0100 {
	[SectionPosition(1)] public JL_JournalIdentification JournalIdentification { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0100>(this);
		validator.Required(x => x.JournalIdentification);
		validator.CollectionSize(x => x.Remarks, 1, 100);
		return validator.Results;
	}
}
