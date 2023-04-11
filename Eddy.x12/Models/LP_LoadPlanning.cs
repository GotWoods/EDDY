using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Internals;

namespace Eddy.x12.Models;

[Segment("LP")]
public class LP_LoadPlanning : EdiX12Segment
{
	[Position(01)]
	public string EquipmentTypeCode { get; set; }

	[Position(02)]
	public string ShipmentIdentificationNumber { get; set; }

	[Position(03)]
	public string ShipmentIdentificationNumber2 { get; set; }

	[Position(04)]
	public string VentInstructionCode { get; set; }

	[Position(05)]
	public string EquipmentNumber { get; set; }

	[Position(06)]
	public int? Number { get; set; }

	[Position(07)]
	public int? Number2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<LP_LoadPlanning>(this);
		validator.Length(x => x.EquipmentTypeCode, 4);
		validator.Length(x => x.ShipmentIdentificationNumber, 1, 30);
		validator.Length(x => x.ShipmentIdentificationNumber2, 1, 30);
		validator.Length(x => x.VentInstructionCode, 1, 7);
		validator.Length(x => x.EquipmentNumber, 1, 15);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.Number2, 1, 9);
		return validator.Results;
	}
}
