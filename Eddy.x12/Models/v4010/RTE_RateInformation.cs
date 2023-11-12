using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("RTE")]
public class RTE_RateInformation : EdiX12Segment
{
	[Position(01)]
	public string RateQualifier { get; set; }

	[Position(02)]
	public decimal? InterestRate { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public int? Number { get; set; }

	[Position(05)]
	public int? Number2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<RTE_RateInformation>(this);
		validator.Required(x=>x.RateQualifier);
		validator.Required(x=>x.InterestRate);
		validator.Length(x => x.RateQualifier, 1, 2);
		validator.Length(x => x.InterestRate, 1, 6);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		return validator.Results;
	}
}
