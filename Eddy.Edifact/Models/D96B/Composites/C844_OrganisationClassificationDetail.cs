using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C844")]
public class C844_OrganisationClassificationDetail : EdifactComponent
{
	[Position(1)]
	public string OrganisationalClassIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string OrganisationalClass { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C844_OrganisationClassificationDetail>(this);
		validator.Length(x => x.OrganisationalClassIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.OrganisationalClass, 1, 70);
		return validator.Results;
	}
}
