using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("IHC")]
public class IHC_PersonCharacteristic : EdifactSegment
{
	[Position(1)]
	public string PersonCharacteristicQualifier { get; set; }

	[Position(2)]
	public C818_PersonInheritedCharacteristicDetails PersonInheritedCharacteristicDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<IHC_PersonCharacteristic>(this);
		validator.Required(x=>x.PersonCharacteristicQualifier);
		validator.Length(x => x.PersonCharacteristicQualifier, 1, 3);
		return validator.Results;
	}
}
