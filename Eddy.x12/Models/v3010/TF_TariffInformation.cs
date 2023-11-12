using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("TF")]
public class TF_TariffInformation : EdiX12Segment
{
	[Position(01)]
	public string TariffAgencyCode { get; set; }

	[Position(02)]
	public string TariffNumber { get; set; }

	[Position(03)]
	public string TariffNumberSuffix { get; set; }

	[Position(04)]
	public string TariffSupplementIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TF_TariffInformation>(this);
		validator.Required(x=>x.TariffAgencyCode);
		validator.Required(x=>x.TariffNumber);
		validator.Length(x => x.TariffAgencyCode, 1, 4);
		validator.Length(x => x.TariffNumber, 1, 7);
		validator.Length(x => x.TariffNumberSuffix, 1, 2);
		validator.Length(x => x.TariffSupplementIdentifier, 1, 4);
		return validator.Results;
	}
}
