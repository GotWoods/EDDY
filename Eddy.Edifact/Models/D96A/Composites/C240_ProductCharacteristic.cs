using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C240")]
public class C240_ProductCharacteristic : EdifactComponent
{
	[Position(1)]
	public string CharacteristicIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string Characteristic { get; set; }

	[Position(5)]
	public string Characteristic2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C240_ProductCharacteristic>(this);
		validator.Required(x=>x.CharacteristicIdentification);
		validator.Length(x => x.CharacteristicIdentification, 1, 17);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.Characteristic, 1, 35);
		validator.Length(x => x.Characteristic2, 1, 35);
		return validator.Results;
	}
}
