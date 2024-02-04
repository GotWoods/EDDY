using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3070;

namespace Eddy.x12.DomainModels.Transportation.v3070._432;

public class LLX {
	[SectionPosition(1)] public LX_AssignedNumber AssignedNumber { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCode> IndustryCode { get; set; } = new();
	[SectionPosition(3)] public List<DRT_DeprescriptionRateDetail> DeprescriptionRateDetail { get; set; } = new();
	[SectionPosition(4)] public List<LLX_LCIC> LCIC {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.AssignedNumber);
		validator.CollectionSize(x => x.IndustryCode, 0, 8);
		validator.CollectionSize(x => x.DeprescriptionRateDetail, 0, 6);
		validator.CollectionSize(x => x.LCIC, 1, 1500);
		foreach (var item in LCIC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
