using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D11A.Composites;

[Segment("C003")]
public class C003_PowerType : EdifactComponent
{
	[Position(1)]
	public string PowerTypeCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string PowerTypeDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C003_PowerType>(this);
		validator.Length(x => x.PowerTypeCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.PowerTypeDescription, 1, 17);
		return validator.Results;
	}
}
