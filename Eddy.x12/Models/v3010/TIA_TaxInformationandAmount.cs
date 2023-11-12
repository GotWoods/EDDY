using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TIA")]
public class TIA_TaxInformationAndAmount : EdiX12Segment
{
	[Position(01)]
	public string TaxInformationCode { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string FixedFormatInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TIA_TaxInformationAndAmount>(this);
		validator.Required(x=>x.TaxInformationCode);
		validator.Length(x => x.TaxInformationCode, 1, 5);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.FixedFormatInformation, 1, 80);
		return validator.Results;
	}
}
