using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C286")]
public class C286_SequenceInformation : EdifactComponent
{
	[Position(1)]
	public string SequencePositionIdentifier { get; set; }

	[Position(2)]
	public string SequenceIdentifierSourceCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C286_SequenceInformation>(this);
		validator.Required(x=>x.SequencePositionIdentifier);
		validator.Length(x => x.SequencePositionIdentifier, 1, 10);
		validator.Length(x => x.SequenceIdentifierSourceCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
