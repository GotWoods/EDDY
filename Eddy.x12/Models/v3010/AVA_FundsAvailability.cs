using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("AVA")]
public class AVA_FundsAvailability : EdiX12Segment
{
	[Position(01)]
	public decimal? MonetaryAmount { get; set; }

	[Position(02)]
	public decimal? Availability { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AVA_FundsAvailability>(this);
		validator.Required(x=>x.MonetaryAmount);
		validator.Required(x=>x.Availability);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.Availability, 1, 6);
		return validator.Results;
	}
}
