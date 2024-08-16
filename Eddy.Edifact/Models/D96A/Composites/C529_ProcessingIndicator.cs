using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C529")]
public class C529_ProcessingIndicator : EdifactComponent
{
	[Position(1)]
	public string ProcessingIndicatorCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string ProcessTypeIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C529_ProcessingIndicator>(this);
		validator.Required(x=>x.ProcessingIndicatorCoded);
		validator.Length(x => x.ProcessingIndicatorCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.ProcessTypeIdentification, 1, 17);
		return validator.Results;
	}
}
