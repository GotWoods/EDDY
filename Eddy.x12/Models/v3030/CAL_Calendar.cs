using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CAL")]
public class CAL_Calendar : EdiX12Segment
{
	[Position(01)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(02)]
	public string ReferenceNumber { get; set; }

	[Position(03)]
	public string UnitOfTimePeriodOrInterval { get; set; }

	[Position(04)]
	public string DateTimeQualifier { get; set; }

	[Position(05)]
	public string Date { get; set; }

	[Position(06)]
	public string Time { get; set; }

	[Position(07)]
	public string TimeCode { get; set; }

	[Position(08)]
	public string ShipDeliveryOrCalendarPatternCode { get; set; }

	[Position(09)]
	public string DateTimeQualifier2 { get; set; }

	[Position(10)]
	public string Date2 { get; set; }

	[Position(11)]
	public string Time2 { get; set; }

	[Position(12)]
	public string TimeCode2 { get; set; }

	[Position(13)]
	public string ShipDeliveryOrCalendarPatternCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CAL_Calendar>(this);
		validator.Required(x=>x.ReferenceNumberQualifier);
		validator.Required(x=>x.ReferenceNumber);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.UnitOfTimePeriodOrInterval, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 6);
		validator.Length(x => x.Time, 4, 6);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode, 1, 2);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 6);
		validator.Length(x => x.Time2, 4, 6);
		validator.Length(x => x.TimeCode2, 2);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode2, 1, 2);
		return validator.Results;
	}
}
