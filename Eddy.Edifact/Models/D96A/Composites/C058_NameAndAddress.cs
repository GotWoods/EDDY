using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C058")]
public class C058_NameAndAddress : EdifactComponent
{
	[Position(1)]
	public string NameAndAddressLine { get; set; }

	[Position(2)]
	public string NameAndAddressLine2 { get; set; }

	[Position(3)]
	public string NameAndAddressLine3 { get; set; }

	[Position(4)]
	public string NameAndAddressLine4 { get; set; }

	[Position(5)]
	public string NameAndAddressLine5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C058_NameAndAddress>(this);
		validator.Required(x=>x.NameAndAddressLine);
		validator.Length(x => x.NameAndAddressLine, 1, 35);
		validator.Length(x => x.NameAndAddressLine2, 1, 35);
		validator.Length(x => x.NameAndAddressLine3, 1, 35);
		validator.Length(x => x.NameAndAddressLine4, 1, 35);
		validator.Length(x => x.NameAndAddressLine5, 1, 35);
		return validator.Results;
	}
}
