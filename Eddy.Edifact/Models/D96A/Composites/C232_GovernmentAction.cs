using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C232")]
public class C232_GovernmentAction : EdifactComponent
{
	[Position(1)]
	public string GovernmentAgencyCoded { get; set; }

	[Position(2)]
	public string GovernmentInvolvementCoded { get; set; }

	[Position(3)]
	public string GovernmentActionCoded { get; set; }

	[Position(4)]
	public string GovernmentProcedureCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C232_GovernmentAction>(this);
		validator.Length(x => x.GovernmentAgencyCoded, 1, 3);
		validator.Length(x => x.GovernmentInvolvementCoded, 1, 3);
		validator.Length(x => x.GovernmentActionCoded, 1, 3);
		validator.Length(x => x.GovernmentProcedureCoded, 1, 3);
		return validator.Results;
	}
}
