using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Finance.v6020._811;

public class LHL_LUSD {
	[SectionPosition(1)] public USD_UsageSensitiveDetail UsageSensitiveDetail { get; set; } = new();
	[SectionPosition(2)] public List<SI_ServiceCharacteristicIdentification> ServiceCharacteristicIdentification { get; set; } = new();
	[SectionPosition(3)] public List<ITA_AllowanceChargeOrService> AllowanceChargeOrService { get; set; } = new();
	[SectionPosition(4)] public List<TRF_RatingFactors> RatingFactors { get; set; } = new();
	[SectionPosition(5)] public List<LHL__LUSD_LQTY> LQTY {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LHL_LUSD>(this);
		validator.Required(x => x.UsageSensitiveDetail);
		validator.CollectionSize(x => x.ServiceCharacteristicIdentification, 0, 2);
		validator.CollectionSize(x => x.AllowanceChargeOrService, 0, 2);
		validator.CollectionSize(x => x.RatingFactors, 0, 18);
		validator.CollectionSize(x => x.LQTY, 1, 2147483647);
		foreach (var item in LQTY) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
