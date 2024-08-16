using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C085")]
public class C085_MaritalStatusDetails : EdifactComponent
{
	[Position(1)]
	public string MaritalStatusDescriptionCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string MaritalStatusDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C085_MaritalStatusDetails>(this);
		validator.Length(x => x.MaritalStatusDescriptionCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.MaritalStatusDescription, 1, 35);
		return validator.Results;
	}
}
