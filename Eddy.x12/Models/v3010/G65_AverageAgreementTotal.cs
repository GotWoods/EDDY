using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G65")]
public class G65_AverageAgreementTotal : EdiX12Segment
{
	[Position(01)]
	public int? NumberOfDays { get; set; }

	[Position(02)]
	public int? NumberOfDays2 { get; set; }

	[Position(03)]
	public string Charge { get; set; }

	[Position(04)]
	public int? NumberOfDays3 { get; set; }

	[Position(05)]
	public decimal? Rate { get; set; }

	[Position(06)]
	public string Amount { get; set; }

	[Position(07)]
	public string Amount2 { get; set; }

	[Position(08)]
	public string Amount3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G65_AverageAgreementTotal>(this);
		validator.Required(x=>x.NumberOfDays);
		validator.Required(x=>x.NumberOfDays2);
		validator.Required(x=>x.Charge);
		validator.Length(x => x.NumberOfDays, 1, 3);
		validator.Length(x => x.NumberOfDays2, 1, 3);
		validator.Length(x => x.Charge, 1, 9);
		validator.Length(x => x.NumberOfDays3, 1, 3);
		validator.Length(x => x.Rate, 1, 7);
		validator.Length(x => x.Amount, 1, 9);
		validator.Length(x => x.Amount2, 1, 9);
		validator.Length(x => x.Amount3, 1, 9);
		return validator.Results;
	}
}
