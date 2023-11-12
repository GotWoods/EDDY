using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("SV6")]
public class SV6_AnesthesiaService : EdiX12Segment
{
	[Position(01)]
	public string ProductServiceIDQualifier { get; set; }

	[Position(02)]
	public string ProductServiceID { get; set; }

	[Position(03)]
	public string FacilityCodeQualifier { get; set; }

	[Position(04)]
	public string FacilityCode { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount { get; set; }

	[Position(06)]
	public int? DiagnosisCodePointer { get; set; }

	[Position(07)]
	public decimal? Quantity { get; set; }

	[Position(08)]
	public string ProcedureModifier { get; set; }

	[Position(09)]
	public int? DiagnosisCodePointer2 { get; set; }

	[Position(10)]
	public string ProcedureModifier2 { get; set; }

	[Position(11)]
	public string ProcedureModifier3 { get; set; }

	[Position(12)]
	public string YesNoConditionOrResponseCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV6_AnesthesiaService>(this);
		validator.Required(x=>x.ProductServiceIDQualifier);
		validator.Required(x=>x.ProductServiceID);
		validator.IfOneIsFilled_AllAreRequired(x=>x.FacilityCodeQualifier, x=>x.FacilityCode);
		validator.Length(x => x.ProductServiceIDQualifier, 2);
		validator.Length(x => x.ProductServiceID, 1, 30);
		validator.Length(x => x.FacilityCodeQualifier, 1, 2);
		validator.Length(x => x.FacilityCode, 1, 2);
		validator.Length(x => x.MonetaryAmount, 1, 15);
		validator.Length(x => x.DiagnosisCodePointer, 1, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.ProcedureModifier, 2);
		validator.Length(x => x.DiagnosisCodePointer2, 1, 2);
		validator.Length(x => x.ProcedureModifier2, 2);
		validator.Length(x => x.ProcedureModifier3, 2);
		validator.Length(x => x.YesNoConditionOrResponseCode, 1);
		return validator.Results;
	}
}
