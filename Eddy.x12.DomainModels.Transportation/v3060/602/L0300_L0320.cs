using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._602;

public class L0300_L0320 {
	[SectionPosition(1)] public SRT_ScaleRateHeader ScaleRateHeader { get; set; } = new();
	[SectionPosition(2)] public List<MIN_MinimumDetail> MinimumDetail { get; set; } = new();
	[SectionPosition(3)] public List<SRD_ScaleRateDetail> ScaleRateDetail { get; set; } = new();
	[SectionPosition(4)] public List<SRM_ScaleRates> ScaleRates { get; set; } = new();
	[SectionPosition(5)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(6)] public List<L0300__L0320_L0321> L0321 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300_L0320>(this);
		validator.Required(x => x.ScaleRateHeader);
		validator.CollectionSize(x => x.MinimumDetail, 0, 100);
		validator.CollectionSize(x => x.ScaleRateDetail, 0, 200);
		validator.CollectionSize(x => x.ScaleRates, 0, 999);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 10);
		validator.CollectionSize(x => x.L0321, 0, 200);
		foreach (var item in L0321) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
