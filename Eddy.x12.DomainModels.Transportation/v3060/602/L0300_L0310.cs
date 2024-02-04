using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._602;

public class L0300_L0310 {
	[SectionPosition(1)] public SC_DocketSubLevel DocketSubLevel { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<CD_ShipmentConditions> ShipmentConditions { get; set; } = new();
	[SectionPosition(4)] public List<L0300__L0310_L0311> L0311 {get;set;} = new();
	[SectionPosition(5)] public List<L0300__L0310_L0312> L0312 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300_L0310>(this);
		validator.Required(x => x.DocketSubLevel);
		validator.CollectionSize(x => x.Geography, 0, 9999);
		validator.CollectionSize(x => x.ShipmentConditions, 0, 100);
		validator.CollectionSize(x => x.L0311, 0, 10);
		validator.CollectionSize(x => x.L0312, 0, 20);
		foreach (var item in L0311) validator.Results.AddRange(item.Validate().Errors);
		foreach (var item in L0312) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
