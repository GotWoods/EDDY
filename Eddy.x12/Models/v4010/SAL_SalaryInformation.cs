using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SAL")]
public class SAL_SalaryInformation : EdiX12Segment
{
	[Position(01)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(02)]
	public string Amount { get; set; }

	[Position(03)]
	public string LaborRate { get; set; }

	[Position(04)]
	public int? NumberOfPeriods { get; set; }

	[Position(05)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(06)]
	public string Date { get; set; }

	[Position(07)]
	public string Date2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SAL_SalaryInformation>(this);
		validator.Required(x=>x.YesNoConditionOrResponseCode);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Amount, 1, 15);
		validator.Length(x => x.LaborRate, 3, 6);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Date2, 8);
		return validator.Results;
	}
}
