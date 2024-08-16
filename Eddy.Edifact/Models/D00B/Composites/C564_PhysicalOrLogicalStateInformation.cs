using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C564")]
public class C564_PhysicalOrLogicalStateInformation : EdifactComponent
{
	[Position(1)]
	public string PhysicalOrLogicalStateDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string PhysicalOrLogicalStateDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C564_PhysicalOrLogicalStateInformation>(this);
		validator.Length(x => x.PhysicalOrLogicalStateDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.PhysicalOrLogicalStateDescription, 1, 70);
		return validator.Results;
	}
}
