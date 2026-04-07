using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._833;

public class LCRO__LLX__LN1_LCDA {
	[SectionPosition(1)] public CDA_ConsumerCreditAccount ConsumerCreditAccount { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public List<PPY_PersonalPropertyDescription> PersonalPropertyDescription { get; set; } = new();
	[SectionPosition(4)] public List<LCRO__LLX__LN1__LCDA_LIN1> LIN1 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LCRO__LLX__LN1_LCDA>(this);
		validator.Required(x => x.ConsumerCreditAccount);
		validator.CollectionSize(x => x.PersonalPropertyDescription, 0, 5);
		validator.CollectionSize(x => x.LIN1, 0, 10);
		foreach (var item in LIN1) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
