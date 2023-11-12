using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5030;

[Segment("PLC")]
public class PLC_EquipmentPlacementInformation : EdiX12Segment
{
	[Position(01)]
	public int? Number { get; set; }

	[Position(02)]
	public string ReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<PLC_EquipmentPlacementInformation>(this);
		validator.Required(x=>x.Number);
		validator.Length(x => x.Number, 1, 9);
		validator.Length(x => x.ReferenceIdentification, 1, 80);
		return validator.Results;
	}
}
