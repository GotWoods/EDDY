using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C218")]
public class C218_HazardousMaterial : EdifactComponent
{
	[Position(1)]
	public string HazardousMaterialClassCodeIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C218_HazardousMaterial>(this);
		validator.Length(x => x.HazardousMaterialClassCodeIdentification, 1, 4);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		return validator.Results;
	}
}