using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C825")]
public class C825_DamageSeverity : EdifactComponent
{
	[Position(1)]
	public string DamageSeverityDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string DamageSeverityDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C825_DamageSeverity>(this);
		validator.Length(x => x.DamageSeverityDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.DamageSeverityDescription, 1, 35);
		return validator.Results;
	}
}
