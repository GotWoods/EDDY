using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C826")]
public class C826_Action : EdifactComponent
{
	[Position(1)]
	public string ActionRequestNotificationDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ActionRequestNotificationDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C826_Action>(this);
		validator.Length(x => x.ActionRequestNotificationDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ActionRequestNotificationDescription, 1, 35);
		return validator.Results;
	}
}
