using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SV1")]
public class SV1_ProfessionalService : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public decimal? MonetaryAmount { get; set; }

	[Position(04)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(05)]
	public decimal? Quantity { get; set; }

	[Position(06)]
	public string FacilityCode { get; set; }

	[Position(07)]
	public string ServiceTypeCode { get; set; }

	[Position(08)]
	public int? DiagnosisCodePointer { get; set; }

	[Position(09)]
	public string ProcedureModifier { get; set; }

	[Position(10)]
	public int? DiagnosisCodePointer2 { get; set; }

	[Position(11)]
	public string ProcedureModifier2 { get; set; }

	[Position(12)]
	public string ProcedureModifier3 { get; set; }

	[Position(13)]
	public string Description { get; set; }

	[Position(14)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(15)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(16)]
	public string MultipleProcedureCode { get; set; }

	[Position(17)]
	public string YesNoConditionOrResponseCode2 { get; set; }

	[Position(18)]
	public string YesNoConditionOrResponseCode3 { get; set; }

	[Position(19)]
	public string ReviewCode { get; set; }

	[Position(20)]
	public string NationalOrLocalAssignedReviewValue { get; set; }

	[Position(21)]
	public string CopayStatusCode { get; set; }

	[Position(22)]
	public string HealthcareManpowerShortageAreaCode { get; set; }

	[Position(23)]
	public string ReferenceNumber { get; set; }

	[Position(24)]
	public string PostalCode { get; set; }

	[Position(25)]
	public decimal? MonetaryAmount3 { get; set; }

	[Position(26)]
	public string LevelOfCareCode { get; set; }

	[Position(27)]
	public string ProviderAgreementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV1_ProfessionalService>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.FacilityCode, 1, 2);
		validator.Length(x => x.ServiceTypeCode, 1, 2);
		validator.Length(x => x.DiagnosisCodePointer, 1, 2);
		validator.Length(x => x.ProcedureModifier, 2);
		validator.Length(x => x.DiagnosisCodePointer2, 1, 2);
		validator.Length(x => x.ProcedureModifier2, 2);
		validator.Length(x => x.ProcedureModifier3, 2);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.MonetaryAmount2, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.MultipleProcedureCode, 1, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode2, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode3, 1);
		validator.Length(x => x.ReviewCode, 1, 2);
		validator.Length(x => x.NationalOrLocalAssignedReviewValue, 1, 2);
		validator.Length(x => x.CopayStatusCode, 1);
		validator.Length(x => x.HealthcareManpowerShortageAreaCode, 1);
		validator.Length(x => x.ReferenceNumber, 1, 30);
		validator.Length(x => x.PostalCode, 3, 9);
		validator.Length(x => x.MonetaryAmount3, 1, 15);
		validator.Length(x => x.LevelOfCareCode, 1);
		validator.Length(x => x.ProviderAgreementCode, 1);
		return validator.Results;
	}
}
