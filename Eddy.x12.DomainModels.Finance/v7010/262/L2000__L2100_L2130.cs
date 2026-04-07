using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7010;

namespace Eddy.x12.DomainModels.Finance.v7010._262;

public class L2000__L2100_L2130 {
	[SectionPosition(1)] public PEX_PropertyOrHousingExpense PropertyOrHousingExpense { get; set; } = new();
	[SectionPosition(2)] public DTP_DateOrTimeOrPeriod? DateOrTimeOrPeriod { get; set; }
	[SectionPosition(3)] public List<III_Information> Information { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L2000__L2100_L2130>(this);
		validator.Required(x => x.PropertyOrHousingExpense);
		validator.CollectionSize(x => x.Information, 1, 2147483647);
		return validator.Results;
	}
}
