using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C108")]
public class C108_TextLiteral : EdifactComponent
{
	[Position(1)]
	public string FreeTextValue { get; set; }

	[Position(2)]
	public string FreeTextValue2 { get; set; }

	[Position(3)]
	public string FreeTextValue3 { get; set; }

	[Position(4)]
	public string FreeTextValue4 { get; set; }

	[Position(5)]
	public string FreeTextValue5 { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C108_TextLiteral>(this);
		validator.Required(x=>x.FreeTextValue);
		validator.Length(x => x.FreeTextValue, 1, 512);
		validator.Length(x => x.FreeTextValue2, 1, 512);
		validator.Length(x => x.FreeTextValue3, 1, 512);
		validator.Length(x => x.FreeTextValue4, 1, 512);
		validator.Length(x => x.FreeTextValue5, 1, 512);
		return validator.Results;
	}
}
