using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C286")]
public class C286_SequenceInformation : EdifactComponent
{
	[Position(1)]
	public string SequenceNumber { get; set; }

	[Position(2)]
	public string SequenceNumberSourceCoded { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C286_SequenceInformation>(this);
		validator.Required(x=>x.SequenceNumber);
		validator.Length(x => x.SequenceNumber, 1, 10);
		validator.Length(x => x.SequenceNumberSourceCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
