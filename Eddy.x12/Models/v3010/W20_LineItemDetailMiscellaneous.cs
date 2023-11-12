using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W20")]
public class W20_LineItemDetailMiscellaneous : EdiX12Segment
{
	[Position(01)]
	public int? Pack { get; set; }

	[Position(02)]
	public decimal? Size { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Weight { get; set; }

	[Position(05)]
	public string WeightQualifier { get; set; }

	[Position(06)]
	public string WeightUnitQualifier { get; set; }

	[Position(07)]
	public decimal? UnitWeight { get; set; }

	[Position(08)]
	public decimal? Volume { get; set; }

	[Position(09)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(10)]
	public string Color { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W20_LineItemDetailMiscellaneous>(this);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.WeightQualifier, 1, 2);
		validator.Length(x => x.WeightUnitQualifier, 1);
		validator.Length(x => x.UnitWeight, 1, 8);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Color, 1, 10);
		return validator.Results;
	}
}
