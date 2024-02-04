using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v8030;

namespace Eddy.x12.DomainModels.Transportation.v8030._432;

public class LLX {
	[SectionPosition(1)] public LX_TransactionSetLineNumber TransactionSetLineNumber { get; set; } = new();
	[SectionPosition(2)] public List<LQ_IndustryCodeIdentification> IndustryCodeIdentification { get; set; } = new();
	[SectionPosition(3)] public List<DRT_CarHireRateDetail> CarHireRateDetail { get; set; } = new();
	[SectionPosition(4)] public List<LLX_LCIC> LCIC {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX>(this);
		validator.Required(x => x.TransactionSetLineNumber);
		validator.CollectionSize(x => x.IndustryCodeIdentification, 0, 8);
		validator.CollectionSize(x => x.CarHireRateDetail, 0, 6);
		validator.CollectionSize(x => x.LCIC, 1, 5000);
		foreach (var item in LCIC) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
