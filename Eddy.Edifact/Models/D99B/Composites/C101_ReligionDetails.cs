using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C101")]
public class C101_ReligionDetails : EdifactComponent
{
	[Position(1)]
	public string ReligionCoded { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string Religion { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C101_ReligionDetails>(this);
		validator.Length(x => x.ReligionCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.Religion, 1, 35);
		return validator.Results;
	}
}