using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("G64")]
public class G64_TotalTimePeriodsAndCharges : EdiX12Segment
{
	[Position(01)]
	public string TimePeriodQualifier { get; set; }

	[Position(02)]
	public int? NumberOfPeriods { get; set; }

	[Position(03)]
	public decimal? Rate { get; set; }

	[Position(04)]
	public string Charge { get; set; }

	[Position(05)]
	public string SpecialChargeOrAllowanceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G64_TotalTimePeriodsAndCharges>(this);
		validator.Required(x=>x.TimePeriodQualifier);
		validator.Required(x=>x.NumberOfPeriods);
		validator.Required(x=>x.Rate);
		validator.Required(x=>x.Charge);
		validator.Length(x => x.TimePeriodQualifier, 1, 2);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.Rate, 1, 7);
		validator.Length(x => x.Charge, 1, 9);
		validator.Length(x => x.SpecialChargeOrAllowanceCode, 3);
		return validator.Results;
	}
}
