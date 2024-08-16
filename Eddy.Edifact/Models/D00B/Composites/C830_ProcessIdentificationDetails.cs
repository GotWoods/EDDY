using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C830")]
public class C830_ProcessIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string ProcessDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ProcessDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C830_ProcessIdentificationDetails>(this);
		validator.Length(x => x.ProcessDescriptionCode, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ProcessDescription, 1, 70);
		return validator.Results;
	}
}
