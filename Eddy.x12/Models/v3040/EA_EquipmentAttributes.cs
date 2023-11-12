using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v3040.Composites;

namespace Eddy.x12.Models.v3040;

[Segment("EA")]
public class EA_EquipmentAttributes : EdiX12Segment
{
	[Position(01)]
	public string EquipmentAttributeCode { get; set; }

	[Position(02)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	[Position(03)]
	public decimal? Quantity { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EA_EquipmentAttributes>(this);
		validator.Required(x=>x.EquipmentAttributeCode);
		validator.Length(x => x.EquipmentAttributeCode, 2, 3);
		validator.Length(x => x.Quantity, 1, 15);
		return validator.Results;
	}
}
