using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C821")]
public class C821_TypeOfDamage : EdifactComponent
{
	[Position(1)]
	public string TypeOfDamageCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string TypeOfDamage { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C821_TypeOfDamage>(this);
		validator.Length(x => x.TypeOfDamageCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.TypeOfDamage, 1, 35);
		return validator.Results;
	}
}
