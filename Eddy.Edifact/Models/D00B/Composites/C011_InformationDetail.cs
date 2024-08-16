using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C011")]
public class C011_InformationDetail : EdifactComponent
{
	[Position(1)]
	public string InformationDetailDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string InformationDetailDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C011_InformationDetail>(this);
		validator.Length(x => x.InformationDetailDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.InformationDetailDescription, 1, 256);
		return validator.Results;
	}
}
