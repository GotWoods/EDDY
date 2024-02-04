using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._217;

public class L0200 {
	[SectionPosition(1)] public N1_Name Name { get; set; } = new();
	[SectionPosition(2)] public List<GY_Geography> Geography { get; set; } = new();
	[SectionPosition(3)] public List<N4_GeographicLocation> GeographicLocation { get; set; } = new();
	[SectionPosition(4)] public LS_LoopHeader? LoopHeader { get; set; }
	[SectionPosition(5)] public List<L0200_L0210> L0210 {get;set;} = new();
	[SectionPosition(6)] public LE_LoopTrailer? LoopTrailer { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0200>(this);
		validator.Required(x => x.Name);
		validator.CollectionSize(x => x.Geography, 0, 9999);
		validator.CollectionSize(x => x.GeographicLocation, 0, 9999);
		validator.CollectionSize(x => x.L0210, 0, 999999);
		foreach (var item in L0210) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
