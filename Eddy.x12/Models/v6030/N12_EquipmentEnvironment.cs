using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.v6030.Composites;

namespace Eddy.x12.Models.v6030;

[Segment("N12")]
public class N12_EquipmentEnvironment : EdiX12Segment
{
	[Position(01)]
	public string FuelTypeCode { get; set; }

	[Position(02)]
	public C001_CompositeUnitOfMeasure CompositeUnitOfMeasure { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N12_EquipmentEnvironment>(this);
		validator.Required(x=>x.FuelTypeCode);
		validator.Required(x=>x.CompositeUnitOfMeasure);
		validator.Length(x => x.FuelTypeCode, 1);
		return validator.Results;
	}
}
