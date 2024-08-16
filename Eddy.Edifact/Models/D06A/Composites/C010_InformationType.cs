using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D06A.Composites;

[Segment("C010")]
public class C010_InformationType : EdifactComponent
{
	[Position(1)]
	public string InformationTypeCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string InformationType { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C010_InformationType>(this);
		validator.Length(x => x.InformationTypeCode, 1, 4);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.InformationType, 1, 35);
		return validator.Results;
	}
}
