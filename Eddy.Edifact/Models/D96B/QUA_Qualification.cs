using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96B.Composites;

namespace Eddy.Edifact.Models.D96B;

[Segment("QUA")]
public class QUA_Qualification : EdifactSegment
{
	[Position(1)]
	public string QualificationQualifier { get; set; }

	[Position(2)]
	public C950_QualificationClassification QualificationClassification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<QUA_Qualification>(this);
		validator.Required(x=>x.QualificationQualifier);
		validator.Length(x => x.QualificationQualifier, 1, 3);
		return validator.Results;
	}
}
