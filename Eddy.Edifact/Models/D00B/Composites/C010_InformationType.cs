using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C010")]
public class C010_InformationType : EdifactComponent
{
	[Position(1)]
	public string InformationTypeDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string InformationTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C010_InformationType>(this);
		validator.Length(x => x.InformationTypeDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.InformationTypeDescription, 1, 70);
		return validator.Results;
	}
}
