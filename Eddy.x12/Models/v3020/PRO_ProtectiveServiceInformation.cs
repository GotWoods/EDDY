using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3020;

[Segment("PRO")]
public class PRO_ProtectiveServiceInformation : EdiX12Segment
{
	[Position(01)]
	public int? Temperature { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(03)]
	public int? Percent { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PRO_ProtectiveServiceInformation>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Temperature, x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.Temperature, 1, 3);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Percent, 1, 3);
		return validator.Results;
	}
}