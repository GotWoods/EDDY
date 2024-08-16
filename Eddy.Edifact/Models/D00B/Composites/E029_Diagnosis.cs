using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("E029")]
public class E029_Diagnosis : EdifactComponent
{
	[Position(1)]
	public string ProductIdentifier { get; set; }

	[Position(2)]
	public string DiagnosisTypeCode { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E029_Diagnosis>(this);
		validator.Required(x=>x.ProductIdentifier);
		validator.Length(x => x.ProductIdentifier, 1, 35);
		validator.Length(x => x.DiagnosisTypeCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		return validator.Results;
	}
}
