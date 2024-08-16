using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C002")]
public class C002_DocumentMessageName : EdifactComponent
{
	[Position(1)]
	public string DocumentNameCode { get; set; }

	[Position(2)]
	public string CodeListIdentificationCode { get; set; }

	[Position(3)]
	public string CodeListResponsibleAgencyCode { get; set; }

	[Position(4)]
	public string DocumentName { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C002_DocumentMessageName>(this);
		validator.Length(x => x.DocumentNameCode, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		validator.Length(x => x.DocumentName, 1, 35);
		return validator.Results;
	}
}
