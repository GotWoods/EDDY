using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("L4")]
public class L4_Measurement : EdiX12Segment
{
	[Position(01)]
	public decimal? Length { get; set; }

	[Position(02)]
	public decimal? Width { get; set; }

	[Position(03)]
	public decimal? Height { get; set; }

	[Position(04)]
	public string MeasurementUnitQualifier { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string IndustryCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<L4_Measurement>(this);
		validator.Required(x=>x.Length);
		validator.Required(x=>x.Width);
		validator.Required(x=>x.Height);
		validator.Required(x=>x.MeasurementUnitQualifier);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.MeasurementUnitQualifier, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.IndustryCode, 1, 30);
		return validator.Results;
	}
}
