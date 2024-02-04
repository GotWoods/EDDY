using System.Collections.Generic;
using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060;

namespace Eddy.x12.DomainModels.Transportation.v7060._210;

public class L0400__L0460_L0463 {
	[SectionPosition(1)] public CD3_CartonPackageDetail CartonPackageDetail { get; set; } = new();
	[SectionPosition(2)] public List<L11_BusinessInstructionsAndReferenceNumber> BusinessInstructionsAndReferenceNumber { get; set; } = new();
	[SectionPosition(3)] public List<H6_SpecialServices> SpecialServices { get; set; } = new();
	[SectionPosition(4)] public List<L9_ChargeDetail> ChargeDetail { get; set; } = new();
	[SectionPosition(5)] public POD_ProofOfDelivery? ProofOfDelivery { get; set; }
	[SectionPosition(6)] public G62_DateTime? DateTime { get; set; }
	public ValidationResult Validate()
	{
		var validator = new TransactionValidator<L0400__L0460_L0463>(this);
		validator.Required(x => x.CartonPackageDetail);
		validator.CollectionSize(x => x.BusinessInstructionsAndReferenceNumber, 0, 20);
		validator.CollectionSize(x => x.SpecialServices, 0, 10);
		validator.CollectionSize(x => x.ChargeDetail, 0, 50);
		return validator.Results;
	}
}
