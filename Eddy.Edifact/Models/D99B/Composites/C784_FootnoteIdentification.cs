using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C784")]
public class C784_FootnoteIdentification : EdifactComponent
{
	[Position(1)]
	public string FootnoteIdentifier { get; set; }

	[Position(2)]
	public string ObjectIdentificationCodeQualifier { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C784_FootnoteIdentification>(this);
		validator.Required(x=>x.FootnoteIdentifier);
		validator.Length(x => x.FootnoteIdentifier, 1, 35);
		validator.Length(x => x.ObjectIdentificationCodeQualifier, 1, 3);
		return validator.Results;
	}
}