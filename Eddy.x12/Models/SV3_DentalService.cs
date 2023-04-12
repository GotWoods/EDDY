using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models;

[Segment("SV3")]
public class SV3_DentalService : EdiX12Segment
{
	[Position(01)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(02)]
	public decimal? MonetaryAmount { get; set; }

	[Position(03)]
	public string FacilityCodeValue { get; set; }

	[Position(04)]
	public C006_OralCavityDesignation OralCavityDesignation { get; set; }

	[Position(05)]
	public string ProsthesisCrownOrInlayCode { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public string Description { get; set; }

	[Position(08)]
	public string CopayStatusCode { get; set; }

	[Position(09)]
	public string ProviderAgreementCode { get; set; }

	[Position(10)]
	public string YesNoConditionOrResponseCode { get; set; }

	[Position(11)]
	public int? DiagnosisCodePointer { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV3_DentalService>(this);
		validator.Required(x=>x.CompositeMedicalProcedureIdentifier);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.FacilityCodeValue, 1, 3);
		validator.Length(x => x.ProsthesisCrownOrInlayCode, 1);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.Description, 1, 80);
		validator.Length(x => x.CopayStatusCode, 1);
		validator.Length(x => x.ProviderAgreementCode, 1);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		validator.Length(x => x.DiagnosisCodePointer, 1, 2);
		return validator.Results;
	}
}
