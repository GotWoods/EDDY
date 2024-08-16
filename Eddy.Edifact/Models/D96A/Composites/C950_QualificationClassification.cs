using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C950")]
public class C950_QualificationClassification : EdifactComponent
{
	[Position(1)]
	public string QualificationClassificationCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string QualificationClassification { get; set; }

	[Position(5)]
	public string QualificationClassification2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C950_QualificationClassification>(this);
		validator.Length(x => x.QualificationClassificationCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.QualificationClassification, 1, 35);
		validator.Length(x => x.QualificationClassification2, 1, 35);
		return validator.Results;
	}
}
