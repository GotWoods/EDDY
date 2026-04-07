using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8010;

namespace Eddy.x12.DomainModels.Finance.v8010._200;

public class LLX__LN1_LSOI {
	[SectionPosition(1)] public SOI_SourceOfIncome SourceOfIncome { get; set; } = new();
	[SectionPosition(2)] public EMS_EmploymentPosition? EmploymentPosition { get; set; }
	[SectionPosition(3)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(4)] public N10_QuantityAndDescription? QuantityAndDescription { get; set; }
	[SectionPosition(5)] public YNQ_YesNoQuestion? YesNoQuestion { get; set; }
	[SectionPosition(6)] public List<LLX__LN1__LSOI_LAIN> LAIN {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LN1_LSOI>(this);
		validator.Required(x => x.SourceOfIncome);
		validator.CollectionSize(x => x.LAIN, 0, 7);
		foreach (var item in LAIN) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
