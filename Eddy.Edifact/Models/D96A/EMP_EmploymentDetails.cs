using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("EMP")]
public class EMP_EmploymentDetails : EdifactSegment
{
	[Position(1)]
	public string EmploymentQualifier { get; set; }

	[Position(2)]
	public C948_EmploymentCategory EmploymentCategory { get; set; }

	[Position(3)]
	public C951_Occupation Occupation { get; set; }

	[Position(4)]
	public C950_QualificationClassification QualificationClassification { get; set; }

	[Position(5)]
	public string JobTitle { get; set; }

	[Position(6)]
	public string QualificationAreaCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EMP_EmploymentDetails>(this);
		validator.Required(x=>x.EmploymentQualifier);
		validator.Length(x => x.EmploymentQualifier, 1, 3);
		validator.Length(x => x.JobTitle, 1, 35);
		validator.Length(x => x.QualificationAreaCoded, 1, 3);
		return validator.Results;
	}
}
