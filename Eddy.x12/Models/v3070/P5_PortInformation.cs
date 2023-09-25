using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3070;

[Segment("P5")]
public class P5_PortInformation : EdiX12Segment
{
	[Position(01)]
	public string PortOrTerminalFunctionCode { get; set; }

	[Position(02)]
	public string LocationQualifier { get; set; }

	[Position(03)]
	public string LocationIdentifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<P5_PortInformation>(this);
		validator.Required(x=>x.PortOrTerminalFunctionCode);
		validator.Required(x=>x.LocationQualifier);
		validator.Required(x=>x.LocationIdentifier);
		validator.Length(x => x.PortOrTerminalFunctionCode, 1);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 30);
		return validator.Results;
	}
}
