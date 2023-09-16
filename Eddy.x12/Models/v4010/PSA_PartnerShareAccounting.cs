using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("PSA")]
public class PSA_PartnerShareAccounting : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(02)]
	public string IdentificationCode { get; set; }

	[Position(03)]
	public decimal? OwnersShare { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public string AmountQualifierCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PSA_PartnerShareAccounting>(this);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.OwnersShare);
		validator.ARequiresB(x=>x.AmountQualifierCode, x=>x.MonetaryAmount);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 80);
		validator.Length(x => x.OwnersShare, 1, 8);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.AmountQualifierCode, 1, 3);
		return validator.Results;
	}
}
