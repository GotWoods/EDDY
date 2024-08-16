using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C059")]
public class C059_Street : EdifactComponent
{
	[Position(1)]
	public string StreetAndNumberOrPostOfficeBoxIdentifier { get; set; }

	[Position(2)]
	public string StreetAndNumberOrPostOfficeBoxIdentifier2 { get; set; }

	[Position(3)]
	public string StreetAndNumberOrPostOfficeBoxIdentifier3 { get; set; }

	[Position(4)]
	public string StreetAndNumberOrPostOfficeBoxIdentifier4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C059_Street>(this);
		validator.Required(x=>x.StreetAndNumberOrPostOfficeBoxIdentifier);
		validator.Length(x => x.StreetAndNumberOrPostOfficeBoxIdentifier, 1, 35);
		validator.Length(x => x.StreetAndNumberOrPostOfficeBoxIdentifier2, 1, 35);
		validator.Length(x => x.StreetAndNumberOrPostOfficeBoxIdentifier3, 1, 35);
		validator.Length(x => x.StreetAndNumberOrPostOfficeBoxIdentifier4, 1, 35);
		return validator.Results;
	}
}
