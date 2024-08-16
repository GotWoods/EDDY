using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C059")]
public class C059_Street : EdifactComponent
{
	[Position(1)]
	public string StreetAndNumberPOBox { get; set; }

	[Position(2)]
	public string StreetAndNumberPOBox2 { get; set; }

	[Position(3)]
	public string StreetAndNumberPOBox3 { get; set; }

	[Position(4)]
	public string StreetAndNumberPOBox4 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C059_Street>(this);
		validator.Required(x=>x.StreetAndNumberPOBox);
		validator.Length(x => x.StreetAndNumberPOBox, 1, 35);
		validator.Length(x => x.StreetAndNumberPOBox2, 1, 35);
		validator.Length(x => x.StreetAndNumberPOBox3, 1, 35);
		validator.Length(x => x.StreetAndNumberPOBox4, 1, 35);
		return validator.Results;
	}
}
