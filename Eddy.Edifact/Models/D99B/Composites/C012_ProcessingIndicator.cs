using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C012")]
public class C012_ProcessingIndicator : EdifactComponent
{
	[Position(1)]
	public string ProcessingIndicatorDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string ProcessingIndicatorDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C012_ProcessingIndicator>(this);
		validator.Length(x => x.ProcessingIndicatorDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.ProcessingIndicatorDescription, 1, 35);
		return validator.Results;
	}
}
