using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C822")]
public class C822_DamageArea : EdifactComponent
{
	[Position(1)]
	public string DamageAreaDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string DamageAreaDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C822_DamageArea>(this);
		validator.Length(x => x.DamageAreaDescriptionCode, 1, 4);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.DamageAreaDescription, 1, 35);
		return validator.Results;
	}
}
