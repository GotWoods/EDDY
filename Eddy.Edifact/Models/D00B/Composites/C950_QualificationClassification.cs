using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C950")]
public class C950_QualificationClassification : EdifactComponent
{
	[Position(1)]
	public string QualificationClassificationDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string QualificationClassificationDescription { get; set; }

	[Position(5)]
	public string QualificationClassificationDescription2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C950_QualificationClassification>(this);
		validator.Length(x => x.QualificationClassificationDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.QualificationClassificationDescription, 1, 35);
		validator.Length(x => x.QualificationClassificationDescription2, 1, 35);
		return validator.Results;
	}
}
