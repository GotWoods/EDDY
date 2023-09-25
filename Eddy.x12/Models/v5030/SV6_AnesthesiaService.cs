using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("SV6")]
public class SV6_AnesthesiaService : EdiX12Segment
{
	[Position(01)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(02)]
	public string FacilityCodeQualifier { get; set; }

	[Position(03)]
	public string FacilityCodeValue { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public C004_CompositeDiagnosisCodePointer CompositeDiagnosisCodePointer { get; set; }

	[Position(06)]
	public decimal? Quantity { get; set; }

	[Position(07)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV6_AnesthesiaService>(this);
		validator.Required(x=>x.CompositeMedicalProcedureIdentifier);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FacilityCodeQualifier, x=>x.FacilityCodeValue);
		validator.Length(x => x.FacilityCodeQualifier, 1, 2);
		validator.Length(x => x.FacilityCodeValue, 1, 3);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
