using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("G20")]
public class G20_ItemPackingDetail : EdiX12Segment
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
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(06)]
	public decimal? Volume { get; set; }

	[Position(07)]
	public string UnitOfMeasurementCode3 { get; set; }

	[Position(08)]
	public string Color { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G20_ItemPackingDetail>(this);
		validator.Length(x => x.Pack, 1, 6);
		validator.Length(x => x.Size, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Weight, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.Volume, 1, 8);
		validator.Length(x => x.UnitOfMeasurementCode3, 2);
		validator.Length(x => x.Color, 1, 10);
		return validator.Results;
	}
}
