using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CAL")]
public class CAL_Calendar : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentificationQualifier { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	[Position(03)]
	public string UnitOfTimePeriodOrIntervalCode { get; set; }

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

	[Position(14)]
	public string QuantityQualifier { get; set; }

	[Position(15)]
	public decimal? Quantity { get; set; }

	[Position(16)]
	public string FreeFormDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CAL_Calendar>(this);
		validator.Required(x=>x.ReferenceIdentificationQualifier);
		validator.Required(x=>x.ReferenceIdentification);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.Length(x => x.ReferenceIdentificationQualifier, 2, 3);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.UnitOfTimePeriodOrIntervalCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.Date, 8);
		validator.Length(x => x.Time, 4, 8);
		validator.Length(x => x.TimeCode, 2);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode, 1, 2);
		validator.Length(x => x.DateTimeQualifier2, 3);
		validator.Length(x => x.Date2, 8);
		validator.Length(x => x.Time2, 4, 8);
		validator.Length(x => x.TimeCode2, 2);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode2, 1, 2);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FreeFormDescription, 1, 45);
		return validator.Results;
	}
}
