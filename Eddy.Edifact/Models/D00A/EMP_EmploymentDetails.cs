using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D00A.Composites;

namespace Eddy.Edifact.Models.D00A;

[Segment("EMP")]
public class EMP_EmploymentDetails : EdifactSegment
{
	[Position(1)]
	public string EmploymentDetailsCodeQualifier { get; set; }

	[Position(2)]
	public C948_EmploymentCategory EmploymentCategory { get; set; }

	[Position(3)]
	public C951_Occupation Occupation { get; set; }

	[Position(4)]
	public C950_QualificationClassification QualificationClassification { get; set; }

	[Position(5)]
	public string JobTitleDescription { get; set; }

	[Position(6)]
	public string QualificationApplicationAreaCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EMP_EmploymentDetails>(this);
		validator.Required(x=>x.EmploymentDetailsCodeQualifier);
		validator.Length(x => x.EmploymentDetailsCodeQualifier, 1, 3);
		validator.Length(x => x.JobTitleDescription, 1, 35);
		validator.Length(x => x.QualificationApplicationAreaCode, 1, 3);
		return validator.Results;
	}
}
