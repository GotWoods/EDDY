using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C956")]
public class C956_AttributeDetails : EdifactComponent
{
	[Position(1)]
	public string AttributeCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Attribute { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C956_AttributeDetails>(this);
		validator.Length(x => x.AttributeCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Attribute, 1, 35);
		return validator.Results;
	}
}
