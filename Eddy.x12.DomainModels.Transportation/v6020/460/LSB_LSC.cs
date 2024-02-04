using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6020;

namespace Eddy.x12.DomainModels.Transportation.v6020._460;

public class LSB_LSC {
	[SectionPosition(1)] public SC_DocketSubLevel DocketSubLevel { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(4)] public List<RAB_RateOrMinimumQualifiers> RateOrMinimumQualifiers { get; set; } = new();
	[SectionPosition(5)] public List<LSB__LSC_LLX> LLX {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LSB_LSC>(this);
		validator.Required(x => x.DocketSubLevel);
		validator.CollectionSize(x => x.Geography, 0, 150);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 150);
		validator.CollectionSize(x => x.RateOrMinimumQualifiers, 0, 48);
		validator.CollectionSize(x => x.LLX, 1, 60);
		foreach (var item in LLX) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
