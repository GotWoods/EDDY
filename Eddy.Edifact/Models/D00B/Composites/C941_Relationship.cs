using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C941")]
public class C941_Relationship : EdifactComponent
{
	[Position(1)]
	public string RelationshipDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string RelationshipDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C941_Relationship>(this);
		validator.Length(x => x.RelationshipDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.RelationshipDescription, 1, 35);
		return validator.Results;
	}
}
