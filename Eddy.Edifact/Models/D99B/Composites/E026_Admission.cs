using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("E026")]
public class E026_Admission : EdifactComponent
{
	[Position(1)]
	public string AdmissionTypeDescriptionCode { get; set; }

	[Position(2)]
	public string AdmissionSourceCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E026_Admission>(this);
		validator.Length(x => x.AdmissionTypeDescriptionCode, 1, 3);
		validator.Length(x => x.AdmissionSourceCode, 1, 3);
		return validator.Results;
	}
}
