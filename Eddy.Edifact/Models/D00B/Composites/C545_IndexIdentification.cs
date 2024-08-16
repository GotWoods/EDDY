using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00B.Composites;

[Segment("C545")]
public class C545_IndexIdentification : EdifactComponent
{
	[Position(1)]
	public string IndexCodeQualifier { get; set; }

	[Position(2)]
	public string IndexTypeIdentifier { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C545_IndexIdentification>(this);
		validator.Required(x=>x.IndexCodeQualifier);
		validator.Length(x => x.IndexCodeQualifier, 1, 3);
		validator.Length(x => x.IndexTypeIdentifier, 1, 17);
		validator.Length(x => x.CodeListIdentificationCode, 1, 17);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
