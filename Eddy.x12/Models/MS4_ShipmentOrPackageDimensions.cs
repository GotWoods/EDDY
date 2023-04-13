using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("MS4")]
public class MS4_ShipmentOrPackageDimensions : EdiX12Segment
{
	[Position(01)]
	public string MeasurementUnitQualifier { get; set; }

	[Position(02)]
	public decimal? Length { get; set; }

	[Position(03)]
	public decimal? Height { get; set; }

	[Position(04)]
	public decimal? Width { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<MS4_ShipmentOrPackageDimensions>(this);
		validator.Required(x=>x.MeasurementUnitQualifier);
		validator.Required(x=>x.Length);
		validator.Required(x=>x.Height);
		validator.Required(x=>x.Width);
		validator.Length(x => x.MeasurementUnitQualifier, 1);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		return validator.Results;
	}
}
