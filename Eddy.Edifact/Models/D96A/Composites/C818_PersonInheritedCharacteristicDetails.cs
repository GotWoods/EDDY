using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C818")]
public class C818_PersonInheritedCharacteristicDetails : EdifactComponent
{
	[Position(1)]
	public string PersonInheritedCharacteristicIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string PersonInheritedCharacteristic { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C818_PersonInheritedCharacteristicDetails>(this);
		validator.Length(x => x.PersonInheritedCharacteristicIdentification, 1, 8);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.PersonInheritedCharacteristic, 1, 70);
		return validator.Results;
	}
}
