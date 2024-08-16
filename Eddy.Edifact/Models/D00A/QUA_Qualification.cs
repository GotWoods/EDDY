using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("QUA")]
public class QUA_Qualification : EdifactSegment
{
	[Position(1)]
	public string QualificationTypeCodeQualifier { get; set; }

	[Position(2)]
	public C950_QualificationClassification QualificationClassification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<QUA_Qualification>(this);
		validator.Required(x=>x.QualificationTypeCodeQualifier);
		validator.Length(x => x.QualificationTypeCodeQualifier, 1, 3);
		return validator.Results;
	}
}
