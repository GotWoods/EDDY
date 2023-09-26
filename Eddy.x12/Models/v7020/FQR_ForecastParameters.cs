using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v7020;

[Segment("FQR")]
public class FQR_ForecastParameters : EdiX12Segment
{
	[Position(01)]
	public string ForecastPurposeCode { get; set; }

	[Position(02)]
	public string ForecastTypeCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<FQR_ForecastParameters>(this);
		validator.Required(x=>x.ForecastPurposeCode);
		validator.Required(x=>x.ForecastTypeCode);
		validator.Required(x=>x.Quantity);
		validator.Length(x => x.ForecastPurposeCode, 2);
		validator.Length(x => x.ForecastTypeCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		return validator.Results;
	}
}
