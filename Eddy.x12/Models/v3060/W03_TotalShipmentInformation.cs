using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("W03")]
public class W03_TotalShipmentInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? NumberOfUnitsShipped { get; set; }

	[Position(02)]
	public decimal? Weight { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Volume { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(06)]
	public int? LadingQuantity { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W03_TotalShipmentInformation>(this);
		validator.Required(x=>x.NumberOfUnitsShipped);
		validator.ARequiresB(x=>x.Weight, x=>x.UnitOrBasisForMeasurementCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Volume, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LadingQuantity, x=>x.UnitOrBasisForMeasurementCode3);
		validator.Length(x => x.NumberOfUnitsShipped, 1, 10);
		validator.Length(x => x.Weight, 1, 10);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.LadingQuantity, 1, 7);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		return validator.Results;
	}
}
