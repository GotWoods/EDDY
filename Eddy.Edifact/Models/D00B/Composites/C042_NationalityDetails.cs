using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C042")]
public class C042_NationalityDetails : EdifactComponent
{
	[Position(1)]
	public string NationalityNameCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string NationalityName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C042_NationalityDetails>(this);
		validator.Length(x => x.NationalityNameCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.NationalityName, 1, 35);
		return validator.Results;
	}
}
