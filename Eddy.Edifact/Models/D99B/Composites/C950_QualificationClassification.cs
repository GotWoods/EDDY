using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C950")]
public class C950_QualificationClassification : EdifactComponent
{
	[Position(1)]
	public string QualificationClassificationCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string QualificationClassification { get; set; }

	[Position(5)]
	public string QualificationClassification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C950_QualificationClassification>(this);
		validator.Length(x => x.QualificationClassificationCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.QualificationClassification, 1, 35);
		validator.Length(x => x.QualificationClassification2, 1, 35);
		return validator.Results;
	}
}