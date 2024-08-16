using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C085")]
public class C085_MaritalStatusDetails : EdifactComponent
{
	[Position(1)]
	public string MaritalStatusCoded { get; set; }

	[Position(2)]
	public string CodeListQualifier { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCoded { get; set; }

	[Position(4)]
	public string MaritalStatus { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C085_MaritalStatusDetails>(this);
		validator.Length(x => x.MaritalStatusCoded, 1, 3);
		validator.Length(x => x.CodeListQualifier, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCoded, 1, 3);
		validator.Length(x => x.MaritalStatus, 1, 35);
		return validator.Results;
	}
}
