using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C215")]
public class C215_SealIssuer : EdifactComponent
{
	[Position(1)]
	public string SealingPartyCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string SealingParty { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C215_SealIssuer>(this);
		validator.Length(x => x.SealingPartyCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.SealingParty, 1, 35);
		return validator.Results;
	}
}
