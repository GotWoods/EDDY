using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.x12.Models;

[Segment("CL1")]
public class CL1_ClaimCodes : EdiX12Segment
{
	[Position(01)]
	public string PriorityTypeOfAdmissionOrVisit { get; set; }

	[Position(02)]
	public string PointOfOriginForAdmissionOrVisit { get; set; }

	[Position(03)]
	public string PatientDischargeStatus { get; set; }

	[Position(04)]
	public string NursingHomeResidentialStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CL1_ClaimCodes>(this);
		validator.Length(x => x.PriorityTypeOfAdmissionOrVisit, 1);
		validator.Length(x => x.PointOfOriginForAdmissionOrVisit, 1);
		validator.Length(x => x.PatientDischargeStatus, 1, 2);
		validator.Length(x => x.NursingHomeResidentialStatusCode, 1);
		return validator.Results;
	}
}
