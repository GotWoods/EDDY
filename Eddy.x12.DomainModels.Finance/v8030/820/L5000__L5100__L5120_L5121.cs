using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Finance.v8030._820;

public class L5000__L5100__L5120_L5121 {
	[SectionPosition(1)] public INV_InvestmentVehicleSelection InvestmentVehicleSelection { get; set; } = new();
	[SectionPosition(2)] public List<DTP_DateOrTimeOrPeriod> DateOrTimeOrPeriod { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L5000__L5100__L5120_L5121>(this);
		validator.Required(x => x.InvestmentVehicleSelection);
		validator.CollectionSize(x => x.DateOrTimeOrPeriod, 1, 2147483647);
		return validator.Results;
	}
}
