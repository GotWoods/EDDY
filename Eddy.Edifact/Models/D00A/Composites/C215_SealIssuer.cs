using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C215")]
public class C215_SealIssuer : EdifactComponent
{
	[Position(1)]
	public string SealingPartyNameCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string SealingPartyName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C215_SealIssuer>(this);
		validator.Length(x => x.SealingPartyNameCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.SealingPartyName, 1, 35);
		return validator.Results;
	}
}