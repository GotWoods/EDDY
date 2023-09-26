using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4030;

[Segment("USI")]
public class USI_UnitizedShipmentInformation : EdiX12Segment
{
	[Position(01)]
	public decimal? Quantity { get; set; }

	[Position(02)]
	public string PackagingFormCode { get; set; }

	[Position(03)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<USI_UnitizedShipmentInformation>(this);
		validator.Required(x=>x.Quantity);
		validator.Required(x=>x.PackagingFormCode);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.PackagingFormCode, 3);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
