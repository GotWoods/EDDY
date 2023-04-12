using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("TOV")]
public class TOV_VehicleUseInformation : EdiX12Segment
{
	[Position(01)]
	public string HazardousVehicleTypeCode { get; set; }

	[Position(02)]
	public string DateTimeQualifier { get; set; }

	[Position(03)]
	public string DateTimePeriodFormatQualifier { get; set; }

	[Position(04)]
	public string DateTimePeriod { get; set; }

	[Position(05)]
	public string QuantityQualifier { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<TOV_VehicleUseInformation>(this);
		validator.Required(x=>x.HazardousVehicleTypeCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.QuantityQualifier, x=>x.Quantity);
		validator.Length(x => x.HazardousVehicleTypeCode, 2);
		validator.Length(x => x.DateTimeQualifier, 3);
		validator.Length(x => x.DateTimePeriodFormatQualifier, 2, 3);
		validator.Length(x => x.DateTimePeriod, 1, 35);
		validator.Length(x => x.QuantityQualifier, 2);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
