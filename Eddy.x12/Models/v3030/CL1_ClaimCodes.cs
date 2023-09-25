using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CL1")]
public class CL1_ClaimCodes : EdiX12Segment
{
	[Position(01)]
	public string AdmissionTypeCode { get; set; }

	[Position(02)]
	public string AdmissionSourceCode { get; set; }

	[Position(03)]
	public string PatientStatusCode { get; set; }

	[Position(04)]
	public string NursingHomeResidentialStatusCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CL1_ClaimCodes>(this);
		validator.Length(x => x.AdmissionTypeCode, 1);
		validator.Length(x => x.AdmissionSourceCode, 1);
		validator.Length(x => x.PatientStatusCode, 1, 2);
		validator.Length(x => x.NursingHomeResidentialStatusCode, 1);
		return validator.Results;
	}
}
