using EdiParser.Attributes;
using EdiParser.Validation;

namespace EdiParser.x12.Models;

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
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Availability, 1, 6);
		return validator.Results;
	}
}
