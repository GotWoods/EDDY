using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("N12")]
public class N12_EquipmentEnvironment : EdiX12Segment
{
	[Position(01)]
	public string FuelType { get; set; }

	[Position(02)]
	public string UnitOfMeasurementCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<N12_EquipmentEnvironment>(this);
		validator.Required(x=>x.FuelType);
		validator.Required(x=>x.UnitOfMeasurementCode);
		validator.Length(x => x.FuelType, 1);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		return validator.Results;
	}
}
