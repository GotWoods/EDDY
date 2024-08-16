using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C242")]
public class C242_ProcessTypeAndDescription : EdifactComponent
{
	[Position(1)]
	public string ProcessTypeIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string ProcessType { get; set; }

	[Position(5)]
	public string ProcessType2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C242_ProcessTypeAndDescription>(this);
		validator.Required(x=>x.ProcessTypeIdentification);
		validator.Length(x => x.ProcessTypeIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.ProcessType, 1, 35);
		validator.Length(x => x.ProcessType2, 1, 35);
		return validator.Results;
	}
}
