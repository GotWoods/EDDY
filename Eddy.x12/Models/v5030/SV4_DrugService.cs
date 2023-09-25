using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("SV4")]
public class SV4_DrugService : EdiX12Segment
{
	[Position(01)]
	public string ReferenceIdentification { get; set; }

	[Position(02)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(03)]
	public string ReferenceIdentification2 { get; set; }

	[Position(04)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(05)]
	public string DispenseAsWrittenCode { get; set; }

	[Position(06)]
	public string LevelOfServiceCode { get; set; }

	[Position(07)]
	public string PrescriptionOriginCode { get; set; }

	[Position(08)]
	public string Description { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(11)]
	public string UnitDoseCode { get; set; }

	[Position(12)]
	public string BasisOfCostDeterminationCode { get; set; }

	[Position(13)]
	public string BasisOfDaysSupplyDeterminationCode { get; set; }

	[Position(14)]
	public string DosageFormCode { get; set; }

	[Position(15)]
	public string CopayStatusCode { get; set; }

	[Position(16)]
	public string PatientLocationCode { get; set; }

	[Position(17)]
	public string LevelOfCareCode { get; set; }

	[Position(18)]
	public string PriorAuthorizationTypeCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV4_DrugService>(this);
		validator.Required(x=>x.ReferenceIdentification);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		validator.Length(x => x.ReferenceIdentification2, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.DispenseAsWrittenCode, 1);
		validator.Length(x => x.LevelOfServiceCode, 1, 3);
		validator.Length(x => x.PrescriptionOriginCode, 1);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.UnitDoseCode, 1);
		validator.Length(x => x.BasisOfCostDeterminationCode, 1, 2);
		validator.Length(x => x.BasisOfDaysSupplyDeterminationCode, 1);
		validator.Length(x => x.DosageFormCode, 2);
		validator.Length(x => x.CopayStatusCode, 1);
		validator.Length(x => x.PatientLocationCode, 1);
		validator.Length(x => x.LevelOfCareCode, 1);
		validator.Length(x => x.PriorAuthorizationTypeCode, 1);
		return validator.Results;
	}
}
