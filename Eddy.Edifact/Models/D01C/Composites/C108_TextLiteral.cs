using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("C108")]
public class C108_TextLiteral : EdifactComponent
{
	[Position(1)]
	public string FreeText { get; set; }

	[Position(2)]
	public string FreeText2 { get; set; }

	[Position(3)]
	public string FreeText3 { get; set; }

	[Position(4)]
	public string FreeText4 { get; set; }

	[Position(5)]
	public string FreeText5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C108_TextLiteral>(this);
		validator.Required(x=>x.FreeText);
		validator.Length(x => x.FreeText, 1, 512);
		validator.Length(x => x.FreeText2, 1, 512);
		validator.Length(x => x.FreeText3, 1, 512);
		validator.Length(x => x.FreeText4, 1, 512);
		validator.Length(x => x.FreeText5, 1, 512);
		return validator.Results;
	}
}
