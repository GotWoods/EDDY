using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3060;

[Segment("SV1")]
public class SV1_ProfessionalService : EdiX12Segment
{
	[Position(01)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(04)]
	public decimal? Quantity { get; set; }

	[Position(05)]
	public string FacilityCodeValue { get; set; }

	[Position(06)]
	public string ServiceTypeCode { get; set; }

	[Position(07)]
	public C004_CompositeDiagnosisCodePointer CompositeDiagnosisCodePointer { get; set; }

	[Position(08)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(09)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(10)]
	public string MultipleProcedureCode { get; set; }

	[Position(11)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(13)]
	public string ReviewCode { get; set; }

	[Position(14)]
	public string NationalOrLocalAssignedReviewValue { get; set; }

	[Position(15)]
	public string CopayStatusCode { get; set; }

	[Position(16)]
	public string HealthCareProfessionalShortageAreaCode { get; set; }

	[Position(17)]
	public string ReferenceIdentification { get; set; }

	[Position(18)]
	public string PostalCode { get; set; }

	[Position(19)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(20)]
	public string LevelOfCareCode { get; set; }

	[Position(21)]
	public string ProviderAgreementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV1_ProfessionalService>(this);
		validator.Required(x=>x.CompositeMedicalProcedureIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FacilityCodeValue, 1, 2);
		validator.Length(x => x.ServiceTypeCode, 1, 2);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.MultipleProcedureCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.ReviewCode, 1, 2);
		validator.Length(x => x.NationalOrLocalAssignedReviewValue, 1, 2);
		validator.Length(x => x.CopayStatusCode, 1);
		validator.Length(x => x.HealthCareProfessionalShortageAreaCode, 1);
		validator.Length(x => x.ReferenceIdentification, 1, 30);
		validator.Length(x => x.PostalCode, 3, 15);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.LevelOfCareCode, 1);
		validator.Length(x => x.ProviderAgreementCode, 1);
		return validator.Results;
	}
}
