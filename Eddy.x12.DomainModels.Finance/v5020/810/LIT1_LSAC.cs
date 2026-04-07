using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v5020;

namespace Eddy.x12.DomainModels.Finance.v5020._810;

public class LIT1_LSAC {
	[SectionPosition(1)] public SAC_ServicePromotionAllowanceOrChargeInformation ServicePromotionAllowanceOrChargeInformation { get; set; } = new();
	[SectionPosition(2)] public List<LIT1__LSAC_LTXI> LTXI {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LIT1_LSAC>(this);
		validator.Required(x => x.ServicePromotionAllowanceOrChargeInformation);
		validator.CollectionSize(x => x.LTXI, 1, 2147483647);
		foreach (var item in LTXI) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
