using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C564")]
public class C564_PhysicalOrLogicalStateInformation : EdifactComponent
{
	[Position(1)]
	public string PhysicalOrLogicalStateCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string PhysicalOrLogicalState { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C564_PhysicalOrLogicalStateInformation>(this);
		validator.Length(x => x.PhysicalOrLogicalStateCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.PhysicalOrLogicalState, 1, 35);
		return validator.Results;
	}
}
