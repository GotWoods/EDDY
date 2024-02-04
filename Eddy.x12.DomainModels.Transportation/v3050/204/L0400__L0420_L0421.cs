using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3050;

namespace Eddy.x12.DomainModels.Transportation.v3050._204;

public class L0400__L0420_L0421 {
	[SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceNumber> ReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(4)] public List<L9_ChargeDetail> ChargeDetail { get; set; } = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400__L0420_L0421>(this);
		validator.Required(x => x.CartonPackageDetail);
		validator.CollectionSize(x => x.ReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.SpecialServices, 0, 10);
		validator.CollectionSize(x => x.ChargeDetail, 0, 10);
		return validator.Results;
	}
}
