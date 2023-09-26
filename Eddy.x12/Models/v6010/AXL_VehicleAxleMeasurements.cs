using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6010;

[Segment("AXL")]
public class AXL_VehicleAxleMeasurements : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public string MeasurementUnitQualifier { get; set; }

	[Position(04)]
	public decimal? Length { get; set; }

	[Position(05)]
	public decimal? Width { get; set; }

	[Position(06)]
	public string WeightQualifier { get; set; }

	[Position(07)]
	public decimal? Weight { get; set; }

	[Position(08)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<AXL_VehicleAxleMeasurements>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.ARequiresB(x=>x.Length, x=>x.MeasurementUnitQualifier);
		validator.ARequiresB(x=>x.Width, x=>x.MeasurementUnitQualifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.WeightQualifier, x=>x.Weight);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 80);
		validator.Length(x => x.MeasurementUnitQualifier, 1);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
