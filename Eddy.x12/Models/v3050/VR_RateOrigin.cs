using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("VR")]
public class VR_RateOrigin : EdiX12Segment
{
	[Position(01)]
	public string TransactionSetPurposeCode { get; set; }

	[Position(02)]
	public string TariffNumber { get; set; }

	[Position(03)]
	public string StandardCarrierAlphaCode { get; set; }

	[Position(04)]
	public string IdentificationCodeQualifier { get; set; }

	[Position(05)]
	public string IdentificationCode { get; set; }

	[Position(06)]
	public string CurrencyCode { get; set; }

	[Position(07)]
	public string TariffAgencyCode { get; set; }

	[Position(08)]
	public string TariffSupplementIdentifier { get; set; }

	[Position(09)]
	public string ExParte { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VR_RateOrigin>(this);
		validator.Required(x=>x.TransactionSetPurposeCode);
		validator.Required(x=>x.TariffNumber);
		validator.Required(x=>x.StandardCarrierAlphaCode);
		validator.Required(x=>x.IdentificationCodeQualifier);
		validator.Required(x=>x.IdentificationCode);
		validator.Required(x=>x.CurrencyCode);
		validator.Length(x => x.TransactionSetPurposeCode, 2);
		validator.Length(x => x.TariffNumber, 1, 7);
		validator.Length(x => x.StandardCarrierAlphaCode, 2, 4);
		validator.Length(x => x.IdentificationCodeQualifier, 1, 2);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.CurrencyCode, 3);
		validator.Length(x => x.TariffAgencyCode, 1, 4);
		validator.Length(x => x.TariffSupplementIdentifier, 1, 4);
		validator.Length(x => x.ExParte, 4);
		return validator.Results;
	}
}
