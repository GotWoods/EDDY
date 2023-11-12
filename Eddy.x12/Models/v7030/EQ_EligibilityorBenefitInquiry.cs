using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v7030.Composites;

namespace Eddy.x12.Models.v7030;

[Segment("EQ")]
public class EQ_EligibilityOrBenefitInquiry : EdiX12Segment
{
	[Position(01)]
	public C064_ServiceType ServiceType { get; set; }

	[Position(02)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(03)]
	public string CoverageLevelCode { get; set; }

	[Position(04)]
	public string InsuranceProductCode { get; set; }

	[Position(05)]
	public int? DiagnosisCodePointer { get; set; }

	[Position(06)]
	public string NetworkIndicatorCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EQ_EligibilityOrBenefitInquiry>(this);
		validator.Length(x => x.CoverageLevelCode, 3);
		validator.Length(x => x.InsuranceProductCode, 1, 3);
		validator.Length(x => x.DiagnosisCodePointer, 1, 2);
		validator.Length(x => x.NetworkIndicatorCode, 1, 2);
		return validator.Results;
	}
}
