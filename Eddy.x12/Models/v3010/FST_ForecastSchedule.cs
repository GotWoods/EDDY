using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("FST")]
public class FST_ForecastSchedule : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string ForecastQualifier { get; set; }

	[Position(03)]
	public string ForecastTimingQualifier { get; set; }

	[Position(04)]
	public string Date { get; set; }

	[Position(05)]
	public string Date2 { get; set; }

	[Position(06)]
	public string DateTimeQualifier { get; set; }

	[Position(07)]
	public string Time { get; set; }

	[Position(08)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(09)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FST_ForecastSchedule>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.ForecastQualifier);
		validator.Required(x=>x.ForecastTimingQualifier);
		validator.Required(x=>x.Date);
		validator.Length(x => x.Quantity, 1, 10);
		validator.Length(x => x.ForecastQualifier, 1);
		validator.Length(x => x.ForecastTimingQualifier, 1);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Time, 4);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
