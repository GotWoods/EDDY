using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4040;

namespace Eddy.x12.DomainModels.Finance.v4040._262;

public class L2000__L2200_L2210 {
	[SectionPosition(1)] public YNQ_YesNoQuestion YesNoQuestion { get; set; } = new();
	[SectionPosition(2)] public REF_ReferenceIdentification ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(4)] public List<L2000__L2200__L2210_L2211> L2211 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2200_L2210>(this);
		validator.Required(x => x.YesNoQuestion);
		validator.Required(x => x.ReferenceIdentification);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 2);
		validator.CollectionSize(x => x.L2211, 0, 50);
		foreach (var item in L2211) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
