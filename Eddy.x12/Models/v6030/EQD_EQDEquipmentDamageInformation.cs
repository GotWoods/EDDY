using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v6030;

[Segment("EQD")]
public class EQD_EQDEquipmentDamageInformation : EdiX12Segment
{
	[Position(01)]
	public string LocationOnEquipmentCode { get; set; }

	[Position(02)]
	public string TypeOfDamageCode { get; set; }

	[Position(03)]
	public string EquipmentComponentCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EQD_EQDEquipmentDamageInformation>(this);
		validator.Required(x=>x.LocationOnEquipmentCode);
		validator.Required(x=>x.TypeOfDamageCode);
		validator.Length(x => x.LocationOnEquipmentCode, 1, 3);
		validator.Length(x => x.TypeOfDamageCode, 1, 3);
		validator.Length(x => x.EquipmentComponentCode, 1, 4);
		return validator.Results;
	}
}
