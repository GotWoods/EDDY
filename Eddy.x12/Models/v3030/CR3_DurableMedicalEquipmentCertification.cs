using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3030;

[Segment("CR3")]
public class CR3_DurableMedicalEquipmentCertification : EdiX12Segment
{
	[Position(01)]
	public string CertificationTypeCode { get; set; }

	[Position(02)]
	public string UnitOrBasisForMeasurementCode { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	[Position(04)]
	public string InsulinDependentCode { get; set; }

	[Position(05)]
	public string Description { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CR3_DurableMedicalEquipmentCertification>(this);
		validator.IfOneIsFilled_AllAreRequired(x=>x.UnitOrBasisForMeasurementCode, x=>x.Quantity);
		validator.Length(x => x.CertificationTypeCode, 1);
		validator.Length(x => x.UnitOrBasisForMeasurementCode, 2);
		validator.Length(x => x.Quantity, 1, 15);
		validator.Length(x => x.InsulinDependentCode, 1);
		validator.Length(x => x.Description, 1, 80);
		return validator.Results;
	}
}
