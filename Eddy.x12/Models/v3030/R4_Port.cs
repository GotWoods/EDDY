using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("R4")]
public class R4_Port : EdiX12Segment
{
	[Position(01)]
	public string PortFunctionCode { get; set; }

	[Position(02)]
	public string LocationQualifier { get; set; }

	[Position(03)]
	public string LocationIdentifier { get; set; }

	[Position(04)]
	public string PortName { get; set; }

	[Position(05)]
	public string CountryCode { get; set; }

	[Position(06)]
	public string TerminalName { get; set; }

	[Position(07)]
	public string PierNumber { get; set; }

	[Position(08)]
	public string StateOrProvinceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<R4_Port>(this);
		validator.Required(x=>x.PortFunctionCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.LocationQualifier, x=>x.LocationIdentifier);
		validator.Length(x => x.PortFunctionCode, 1);
		validator.Length(x => x.LocationQualifier, 1, 2);
		validator.Length(x => x.LocationIdentifier, 1, 25);
		validator.Length(x => x.PortName, 2, 24);
		validator.Length(x => x.CountryCode, 2, 3);
		validator.Length(x => x.TerminalName, 2, 30);
		validator.Length(x => x.PierNumber, 1, 4);
		validator.Length(x => x.StateOrProvinceCode, 2);
		return validator.Results;
	}
}
