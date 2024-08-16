using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C564")]
public class C564_PhysicalOrLogicalStateInformation : EdifactComponent
{
	[Position(1)]
	public string PhysicalOrLogicalStateCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string PhysicalOrLogicalState { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C564_PhysicalOrLogicalStateInformation>(this);
		validator.Length(x => x.PhysicalOrLogicalStateCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.PhysicalOrLogicalState, 1, 70);
		return validator.Results;
	}
}
