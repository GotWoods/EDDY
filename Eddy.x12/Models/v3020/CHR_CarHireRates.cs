using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("CHR")]
public class CHR_CarHireRates : EdiX12Segment
{
	[Position(01)]
	public string RateSource { get; set; }

	[Position(02)]
	public string BilledRatedAsQualifier { get; set; }

	[Position(03)]
	public decimal? Multiplier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CHR_CarHireRates>(this);
		validator.Required(x=>x.RateSource);
		validator.Required(x=>x.BilledRatedAsQualifier);
		validator.Length(x => x.RateSource, 1);
		validator.Length(x => x.BilledRatedAsQualifier, 2);
		validator.Length(x => x.Multiplier, 1, 10);
		return validator.Results;
	}
}
