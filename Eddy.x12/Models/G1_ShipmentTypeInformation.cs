using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("G1")]
public class G1_ShipmentTypeInformation : EdiX12Segment
{
	[Position(01)]
	public string ShipmentTypeCode { get; set; }

	[Position(02)]
	public string SpecialIndicatorCode { get; set; }

	[Position(03)]
	public string SpecialIndicatorCode2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<G1_ShipmentTypeInformation>(this);
		validator.Required(x=>x.ShipmentTypeCode);
		validator.Length(x => x.ShipmentTypeCode, 1, 2);
		validator.Length(x => x.SpecialIndicatorCode, 1);
		validator.Length(x => x.SpecialIndicatorCode2, 1);
		return validator.Results;
	}
}
