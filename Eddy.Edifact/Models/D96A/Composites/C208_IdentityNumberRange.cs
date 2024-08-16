using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C208")]
public class C208_IdentityNumberRange : EdifactComponent
{
	[Position(1)]
	public string IdentityNumber { get; set; }

	[Position(2)]
	public string IdentityNumber2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C208_IdentityNumberRange>(this);
		validator.Required(x=>x.IdentityNumber);
		validator.Length(x => x.IdentityNumber, 1, 35);
		validator.Length(x => x.IdentityNumber2, 1, 35);
		return validator.Results;
	}
}
