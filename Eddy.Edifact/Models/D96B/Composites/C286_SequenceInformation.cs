using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C286")]
public class C286_SequenceInformation : EdifactComponent
{
	[Position(1)]
	public string SequenceNumber { get; set; }

	[Position(2)]
	public string SequenceNumberSourceCoded { get; set; }

	[Position(3)]
	public string CodeListQualifier { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C286_SequenceInformation>(this);
		validator.Required(x=>x.SequenceNumber);
		validator.Length(x => x.SequenceNumber, 1, 10);
		validator.Length(x => x.SequenceNumberSourceCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}
