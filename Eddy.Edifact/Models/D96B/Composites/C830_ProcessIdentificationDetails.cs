using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96B.Composites;

[Segment("C830")]
public class C830_ProcessIdentificationDetails : EdifactComponent
{
	[Position(1)]
	public string ProcessIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Process { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C830_ProcessIdentificationDetails>(this);
		validator.Length(x => x.ProcessIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Process, 1, 70);
		return validator.Results;
	}
}
