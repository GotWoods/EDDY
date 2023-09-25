using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("EMS")]
public class EMS_EmploymentPosition : EdiX12Segment
{
	[Position(01)]
	public string Description { get; set; }

	[Position(02)]
	public string EmploymentClassCode { get; set; }

	[Position(03)]
	public string OccupationCode { get; set; }

	[Position(04)]
	public string EmploymentStatusCode { get; set; }

	[Position(05)]
	public string ReferenceNumberQualifier { get; set; }

	[Position(06)]
	public string ReferenceNumber { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EMS_EmploymentPosition>(this);
		validator.Required(x=>x.Description);
		validator.Required(x=>x.EmploymentClassCode);
		validator.IfOneIsFilled_AllAreRequired(x=>x.ReferenceNumberQualifier, x=>x.ReferenceNumber);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.EmploymentClassCode, 2, 3);
		validator.Length(x => x.OccupationCode, 4, 6);
		validator.Length(x => x.EmploymentStatusCode, 2);
		validator.Length(x => x.ReferenceNumberQualifier, 2);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		return validator.Results;
	}
}
