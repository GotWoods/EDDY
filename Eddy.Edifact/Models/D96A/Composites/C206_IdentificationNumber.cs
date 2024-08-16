using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C206")]
public class C206_IdentificationNumber : EdifactComponent
{
	[Position(1)]
	public string IdentityNumber { get; set; }

	[Position(2)]
	public string IdentityNumberQualifier { get; set; }

	[Position(3)]
	public string StatusCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C206_IdentificationNumber>(this);
		validator.Required(x=>x.IdentityNumber);
		validator.Length(x => x.IdentityNumber, 1, 35);
		validator.Length(x => x.IdentityNumberQualifier, 1, 3);
		validator.Length(x => x.StatusCoded, 1, 3);
		return validator.Results;
	}
}
