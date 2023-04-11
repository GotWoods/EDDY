using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("HSD")]
public class HSD_HealthCareServicesDelivery : EdiX12Segment
{
	[Position(01)]
	public string QuantityQualifier { get; set; }

	[Position(02)]
	public decimal? Quantity { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? SampleSelectionModulus { get; set; }

	[Position(05)]
	public string TimePeriodQualifier { get; set; }

	[Position(06)]
	public int? NumberOfPeriods { get; set; }

	[Position(07)]
	public string ShipDeliveryOrCalendarPatternCode { get; set; }

	[Position(08)]
	public string ShipDeliveryPatternTimeCode { get; set; }

	[Position(09)]
	public int? NumberOfPeriods2 { get; set; }

	[Position(10)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<HSD_HealthCareServicesDelivery>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.ARequiresB(x=>x.NumberOfPeriods, x=>x.TimePeriodQualifier);
		validator.ARequiresB(x=>x.NumberOfPeriods2, x=>x.TimePeriodQualifier);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.SampleSelectionModulus, 1, 6);
		validator.Length(x => x.TimePeriodQualifier, 1, 2);
		validator.Length(x => x.NumberOfPeriods, 1, 3);
		validator.Length(x => x.ShipDeliveryOrCalendarPatternCode, 1, 2);
		validator.Length(x => x.ShipDeliveryPatternTimeCode, 1);
		validator.Length(x => x.NumberOfPeriods2, 1, 3);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
