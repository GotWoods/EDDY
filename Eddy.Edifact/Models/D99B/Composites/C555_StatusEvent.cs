using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C555")]
public class C555_Status : EdifactComponent
{
	[Position(1)]
	public string StatusDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string StatusDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C555_Status>(this);
		validator.Required(x=>x.StatusDescriptionCode);
		validator.Length(x => x.StatusDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.StatusDescription, 1, 35);
		return validator.Results;
	}
}
