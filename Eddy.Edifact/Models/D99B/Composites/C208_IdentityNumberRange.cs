using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C208")]
public class C208_IdentityNumberRange : EdifactComponent
{
	[Position(1)]
	public string ObjectIdentifier { get; set; }

	[Position(2)]
	public string ObjectIdentifier2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C208_IdentityNumberRange>(this);
		validator.Required(x=>x.ObjectIdentifier);
		validator.Length(x => x.ObjectIdentifier, 1, 35);
		validator.Length(x => x.ObjectIdentifier2, 1, 35);
		return validator.Results;
	}
}
