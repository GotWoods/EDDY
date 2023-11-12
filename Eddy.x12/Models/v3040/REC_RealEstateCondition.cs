using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3040;

[Segment("REC")]
public class REC_RealEstateCondition : EdiX12Segment
{
	[Position(01)]
	public string OccupancyCode { get; set; }

	[Position(02)]
	public string RealEstatePropertyConditionCode { get; set; }

	[Position(03)]
	public string PropertyDamageCode { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<REC_RealEstateCondition>(this);
		validator.Required(x=>x.OccupancyCode);
		validator.Length(x => x.OccupancyCode, 2);
		validator.Length(x => x.RealEstatePropertyConditionCode, 2);
		validator.Length(x => x.PropertyDamageCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
