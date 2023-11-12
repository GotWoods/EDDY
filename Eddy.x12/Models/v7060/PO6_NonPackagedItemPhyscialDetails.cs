using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7060.Composites;

namespace Eddy.x12.Models.v7060;

[Segment("PO6")]
public class PO6_NonPackagedItemPhyscialDetails : EdiX12Segment
{
	[Position(01)]
	public C067_CompositeProductWeightBasis CompositeProductWeightBasis { get; set; }

	[Position(02)]
	public decimal? Length { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Width { get; set; }

	[Position(05)]
	public string UnitOrBasisForMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? Height { get; set; }

	[Position(07)]
	public string UnitOrBasisForMeasurementCode3 { get; set; }

	[Position(08)]
	public decimal? ItemDepth { get; set; }

	[Position(09)]
	public string UnitOrBasisForMeasurementCode4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PO6_NonPackagedItemPhyscialDetails>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Length, x=>x.UnitOrBasisForMeasurementCode);
		validator.OnlyOneOf(x=>x.Length, x=>x.ItemDepth);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Width, x=>x.UnitOrBasisForMeasurementCode2);
		validator.IfOneIsFilled_AllAreRequired(x=>x.Height, x=>x.UnitOrBasisForMeasurementCode3);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ItemDepth, x=>x.UnitOrBasisForMeasurementCode4);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode2, 2);
		validator.Length(x => x.Height, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode3, 2);
		validator.Length(x => x.ItemDepth, 1, 6);
		validator.Length(x => x.UnitOrBasisForMeasurementCode4, 2);
		return validator.Results;
	}
}
