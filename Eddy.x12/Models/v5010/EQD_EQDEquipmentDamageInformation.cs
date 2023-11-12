using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.x12.Models.Elements;

namespace Eddy.x12.Models.v5010;

[Segment("EQD")]
public class EQD_EQDEquipmentDamageInformation : EdiX12Segment
{
	[Position(01)]
	public string DamageLocationOnEquipment { get; set; }

	[Position(02)]
	public string TypeOfDamage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<EQD_EQDEquipmentDamageInformation>(this);
		validator.Required(x=>x.DamageLocationOnEquipment);
		validator.Required(x=>x.TypeOfDamage);
		validator.Length(x => x.DamageLocationOnEquipment, 1, 3);
		validator.Length(x => x.TypeOfDamage, 1, 3);
		return validator.Results;
	}
}
