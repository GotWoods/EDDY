using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("V4")]
public class V4_CargoLocationReference : EdiX12Segment
{
	[Position(01)]
	public string VesselStowageLocation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<V4_CargoLocationReference>(this);
		validator.Required(x=>x.VesselStowageLocation);
		validator.Length(x => x.VesselStowageLocation, 1, 12);
		return validator.Results;
	}
}
