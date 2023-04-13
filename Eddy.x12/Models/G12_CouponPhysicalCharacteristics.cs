using Eddy.Core.Attributes;
using Eddy.Core.Validation;


namespace Eddy.x12.Models;

[Segment("G12")]
public class G12_CouponPhysicalCharacteristics : EdiX12Segment
{
	[Position(01)]
	public decimal? Length { get; set; }

	[Position(02)]
	public decimal? Width { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string PromotionConditionCode { get; set; }

	[Position(06)]
	public string PositionCode { get; set; }

	[Position(07)]
	public string PositionCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G12_CouponPhysicalCharacteristics>(this);
		validator.ARequiresB(x=>x.PositionCode2, x=>x.PositionCode);
		validator.Length(x => x.Length, 1, 8);
		validator.Length(x => x.Width, 1, 8);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PromotionConditionCode, 2);
		validator.Length(x => x.PositionCode, 2);
		validator.Length(x => x.PositionCode2, 2);
		return validator.Results;
	}
}
