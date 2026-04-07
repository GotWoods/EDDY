using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v4020;

namespace Eddy.x12.DomainModels.Finance.v4020._205;

public class LMNC__LCDI_LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<VDI_ValueDescriptionOrInformation> ValueDescriptionOrInformation { get; set; } = new();
	[SectionPosition(3)] public List<YNQ_YesNoQuestion> YesNoQuestion { get; set; } = new();
	[SectionPosition(4)] public List<AMT_MonetaryAmount> MonetaryAmount { get; set; } = new();
	[SectionPosition(5)] public List<PCT_PercentAmounts> PercentAmounts { get; set; } = new();
	[SectionPosition(6)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	[SectionPosition(7)] public List<III_Information> Information { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LMNC__LCDI_LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.ValueDescriptionOrInformation, 1, 2147483647);
		validator.CollectionSize(x => x.YesNoQuestion, 0, 4);
		validator.CollectionSize(x => x.MonetaryAmount, 0, 6);
		validator.CollectionSize(x => x.PercentAmounts, 0, 6);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 0, 5);
		validator.CollectionSize(x => x.Information, 0, 12);
		return validator.Results;
	}
}
