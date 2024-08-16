using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C889")]
public class C889_CharacteristicValue : EdifactComponent
{
	[Position(1)]
	public string CharacteristicValueCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string CharacteristicValue { get; set; }

	[Position(5)]
	public string CharacteristicValue2 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C889_CharacteristicValue>(this);
		validator.Length(x => x.CharacteristicValueCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.CharacteristicValue, 1, 35);
		validator.Length(x => x.CharacteristicValue2, 1, 35);
		return validator.Results;
	}
}
