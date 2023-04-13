using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("PCT")]
public class PCT_PercentAmounts : EdiX12Segment
{
	[Position(01)]
	public string PercentQualifier { get; set; }

	[Position(02)]
	public decimal? PercentageAsDecimal { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PCT_PercentAmounts>(this);
		validator.Required(x=>x.PercentQualifier);
		validator.Required(x=>x.PercentageAsDecimal);
		validator.Length(x => x.PercentQualifier, 1, 2);
		validator.Length(x => x.PercentageAsDecimal, 1, 10);
		return validator.Results;
	}
}
