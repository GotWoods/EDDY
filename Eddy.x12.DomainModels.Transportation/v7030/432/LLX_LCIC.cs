using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030;

namespace Eddy.x12.DomainModels.Transportation.v7030._432;

public class LLX_LCIC {
	[SectionPosition(1)] public CIC_CarInformationControl CarInformationControl { get; set; } = new();
	[SectionPosition(2)] public List<DRT_CarHireRateDetail> CarHireRateDetail { get; set; } = new();
	[SectionPosition(3)] public QTY_QuantityInformation? QuantityInformation { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<LLX_LCIC>(this);
		validator.Required(x => x.CarInformationControl);
		validator.CollectionSize(x => x.CarHireRateDetail, 0, 12);
		return validator.Results;
	}
}
