using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C545")]
public class C545_IndexIdentification : EdifactComponent
{
	[Position(1)]
	public string IndexQualifier { get; set; }

	[Position(2)]
	public string IndexTypeCoded { get; set; }

	[Position(3)]
	public string CodeListIdentificationCode { get; set; }

	[Position(4)]
	public string CodeListResponsibleAgencyCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C545_IndexIdentification>(this);
		validator.Required(x=>x.IndexQualifier);
		validator.Length(x => x.IndexQualifier, 1, 3);
		validator.Length(x => x.IndexTypeCoded, 1, 3);
		validator.Length(x => x.CodeListIdentificationCode, 1, 3);
		validator.Length(x => x.CodeListResponsibleAgencyCode, 1, 3);
		return validator.Results;
	}
}
