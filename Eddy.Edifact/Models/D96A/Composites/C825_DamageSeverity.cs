using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C825")]
public class C825_DamageSeverity : EdifactComponent
{
	[Position(1)]
	public string DamageSeverityCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string DamageSeverity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C825_DamageSeverity>(this);
		validator.Length(x => x.DamageSeverityCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.DamageSeverity, 1, 35);
		return validator.Results;
	}
}
