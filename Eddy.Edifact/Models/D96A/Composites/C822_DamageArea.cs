using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C822")]
public class C822_DamageArea : EdifactComponent
{
	[Position(1)]
	public string DamageAreaIdentification { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string DamageArea { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C822_DamageArea>(this);
		validator.Length(x => x.DamageAreaIdentification, 1, 4);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.DamageArea, 1, 35);
		return validator.Results;
	}
}