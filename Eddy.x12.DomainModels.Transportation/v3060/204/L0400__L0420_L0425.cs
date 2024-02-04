using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3060;

namespace Eddy.x12.DomainModels.Transportation.v3060._204;

public class L0400__L0420_L0425 {
	[SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
	[SectionPosition(2)] public List<N9_ReferenceIdentification> ReferenceIdentification { get; set; } = new();
	[SectionPosition(3)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(4)] public List<L9_ChargeDetail> ChargeDetail { get; set; } = new();
	[SectionPosition(5)] public List<MAN_MarksAndNumbers> MarksAndNumbers { get; set; } = new();
	[SectionPosition(6)] public List<L0400__L0420__L0425_L0430> L0430 {get;set;} = new();
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400__L0420_L0425>(this);
		validator.Required(x => x.CartonPackageDetail);
		validator.CollectionSize(x => x.ReferenceIdentification, 0, 20);
		validator.CollectionSize(x => x.SpecialServices, 0, 10);
		validator.CollectionSize(x => x.ChargeDetail, 0, 10);
		validator.CollectionSize(x => x.MarksAndNumbers, 0, 9999);
		validator.CollectionSize(x => x.L0430, 0, 999999);
		foreach (var item in L0430) validator.Results.AddRange(item.Validate().Errors);
		return validator.Results;
	}
}
