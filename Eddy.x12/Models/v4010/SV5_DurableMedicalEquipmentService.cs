using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v4010;

[Segment("SV5")]
public class SV5_DurableMedicalEquipmentService : EdiX12Segment
{
	[Position(01)]
	public C003_CompositeMedicalProcedureIdentifier CompositeMedicalProcedureIdentifier { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public decimal? MonetaryAmount { get; set; }

	[Position(05)]
	public decimal? MonetaryAmount2 { get; set; }

	[Position(06)]
	public string FrequencyCode { get; set; }

	[Position(07)]
	public string PrognosisCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SV5_DurableMedicalEquipmentService>(this);
		validator.Required(x=>x.CompositeMedicalProcedureIdentifier);
		validator.Required(x=>x.UnitOrBasisForMeasurementCode);
		validator.Required(x=>x.Quantity);
		validator.AtLeastOneIsRequired(x=>x.MonetaryAmount, x=>x.MonetaryAmount2);
		validator.ARequiresB(x=>x.FrequencyCode, x=>x.MonetaryAmount);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.MonetaryAmount, 1, 18);
		validator.Length(x => x.MonetaryAmount2, 1, 18);
		validator.Length(x => x.FrequencyCode, 1);
		validator.Length(x => x.PrognosisCode, 1);
		return validator.Results;
	}
}
