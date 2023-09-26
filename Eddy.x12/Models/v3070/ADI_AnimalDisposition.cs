using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("ADI")]
public class ADI_AnimalDisposition : EdiX12Segment
{
	[Position(01)]
	public string AnimalDispositionCode { get; set; }

	[Position(02)]
	public string Date { get; set; }

	[Position(03)]
	public int? TestPeriodOrIntervalValue { get; set; }

	[Position(04)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ADI_AnimalDisposition>(this);
		validator.Required(x=>x.AnimalDispositionCode);
		validator.Required(x=>x.Date);
		validator.IfOneIsFilled_AllAreRequired(x=>x.TestPeriodOrIntervalValue, x=>x.UnitOfTimePeriodOrInterval);
		validator.Length(x => x.AnimalDispositionCode, 2);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.TestPeriodOrIntervalValue, 1, 6);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		return validator.Results;
	}
}
