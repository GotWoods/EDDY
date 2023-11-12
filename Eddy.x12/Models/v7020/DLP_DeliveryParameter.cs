using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7020;

[Segment("DLP")]
public class DLP_DeliveryParameter : EdiX12Segment
{
	[Position(01)]
	public string DeliveryTimeMeasurementTypeCode { get; set; }

	[Position(02)]
	public string AppointmentTimeBasisCode { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<DLP_DeliveryParameter>(this);
		validator.Required(x=>x.DeliveryTimeMeasurementTypeCode);
		validator.Required(x=>x.AppointmentTimeBasisCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.DeliveryTimeMeasurementTypeCode, 2);
		validator.Length(x => x.AppointmentTimeBasisCode, 2);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
