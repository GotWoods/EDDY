using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C515")]
public class C515_TestReason : EdifactComponent
{
	[Position(1)]
	public string TestReasonIdentification { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string TestReason { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C515_TestReason>(this);
		validator.Length(x => x.TestReasonIdentification, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.TestReason, 1, 35);
		return validator.Results;
	}
}
