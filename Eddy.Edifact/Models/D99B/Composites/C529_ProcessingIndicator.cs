using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C529")]
public class C529_ProcessingIndicator : EdifactComponent
{
	[Position(1)]
	public string ProcessingIndicatorDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ProcessTypeDescriptionCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C529_ProcessingIndicator>(this);
		validator.Required(x=>x.ProcessingIndicatorDescriptionCode);
		validator.Length(x => x.ProcessingIndicatorDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ProcessTypeDescriptionCode, 1, 17);
		return validator.Results;
	}
}
