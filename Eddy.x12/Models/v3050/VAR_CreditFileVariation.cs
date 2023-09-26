using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3050;

[Segment("VAR")]
public class VAR_CreditFileVariation : EdiX12Segment
{
	[Position(01)]
	public string IdentificationCode { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string CreditFileVariationCode { get; set; }

	[Position(04)]
	public string CreditFileVariationCode2 { get; set; }

	[Position(05)]
	public string CreditFileVariationCode3 { get; set; }

	[Position(06)]
	public string CreditFileVariationCode4 { get; set; }

	[Position(07)]
	public string CreditFileVariationCode5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<VAR_CreditFileVariation>(this);
		validator.Required(x=>x.IdentificationCode);
		validator.Length(x => x.IdentificationCode, 2, 20);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.CreditFileVariationCode, 2);
		validator.Length(x => x.CreditFileVariationCode2, 2);
		validator.Length(x => x.CreditFileVariationCode3, 2);
		validator.Length(x => x.CreditFileVariationCode4, 2);
		validator.Length(x => x.CreditFileVariationCode5, 2);
		return validator.Results;
	}
}
