using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3030;

namespace Eddy.x12.DomainModels.Transportation.v3030._602;

public class L0300_L0320 {
	[SectionPosition(1)] public SRT_RouteMinimumWeightDetail RouteMinimumWeightDetail { get; set; } = new();
	[SectionPosition(2)] public List<MIN_MinimumDetail> MinimumDetail { get; set; } = new();
	[SectionPosition(3)] public List<SRD_ScaleRateDetail> ScaleRateDetail { get; set; } = new();
	[SectionPosition(4)] public List<SRM_ScaleRates> ScaleRates { get; set; } = new();
	[SectionPosition(5)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0300_L0320>(this);
		validator.Required(x => x.RouteMinimumWeightDetail);
		validator.CollectionSize(x => x.MinimumDetail, 0, 2);
		validator.CollectionSize(x => x.ScaleRateDetail, 0, 200);
		validator.CollectionSize(x => x.ScaleRates, 0, 999);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 10);
		return validator.Results;
	}
}
