using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3020;

namespace Eddy.x12.DomainModels.Transportation.v3020._468;

public class LJL {
	[SectionPosition(1)] public JL_JournalIdentification JournalIdentification { get; set; } = new();
	[SectionPosition(2)] public List<K1_Remarks> Remarks { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LJL>(this);
		validator.Required(x => x.JournalIdentification);
		validator.CollectionSize(x => x.Remarks, 1, 100);
		return validator.Results;
	}
}
