using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v3010;

[Segment("W09")]
public class W09_EquipmentAndTemperature : EdiX12Segment
{
	[Position(01)]
	public string EquipmentDescriptionCode { get; set; }

	[Position(02)]
	public int? Temperature { get; set; }

	[Position(03)]
	public string UnitOfMeasurementCode { get; set; }

	[Position(04)]
	public int? Temperature2 { get; set; }

	[Position(05)]
	public string UnitOfMeasurementCode2 { get; set; }

	[Position(06)]
	public string FreeFormMessage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<W09_EquipmentAndTemperature>(this);
		validator.Required(x=>x.EquipmentDescriptionCode);
		validator.Length(x => x.EquipmentDescriptionCode, 2);
		validator.Length(x => x.Temperature, 1, 3);
		validator.Length(x => x.UnitOfMeasurementCode, 2);
		validator.Length(x => x.Temperature2, 1, 3);
		validator.Length(x => x.UnitOfMeasurementCode2, 2);
		validator.Length(x => x.FreeFormMessage, 1, 60);
		return validator.Results;
	}
}
