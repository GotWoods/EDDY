using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5010;

namespace Eddy.x12.DomainModels.Finance.v5010._820;

public class LLX__LNM1__LPEN_LINV {
	[SectionPosition(1)] public INV_InvestmentVehicleSelection InvestmentVehicleSelection { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX__LNM1__LPEN_LINV>(this);
		validator.Required(x => x.InvestmentVehicleSelection);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		return validator.Results;
	}
}
