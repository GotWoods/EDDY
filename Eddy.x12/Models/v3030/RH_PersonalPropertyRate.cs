using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("RH")]
public class RH_PersonalPropertyRate : EdiX12Segment
{
	[Position(01)]
	public string TariffServiceCode { get; set; }

	[Position(02)]
	public string RateValueQualifier { get; set; }

	[Position(03)]
	public decimal? FreightRate { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RH_PersonalPropertyRate>(this);
		validator.ARequiresB(x=>x.FreightRate, x=>x.RateValueQualifier);
		validator.Length(x => x.TariffServiceCode, 2);
		validator.Length(x => x.RateValueQualifier, 2);
		validator.Length(x => x.FreightRate, 1, 9);
		return validator.Results;
	}
}
