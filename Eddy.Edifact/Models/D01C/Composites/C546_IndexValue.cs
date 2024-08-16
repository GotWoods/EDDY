using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D01C.Composites;

[Segment("C546")]
public class C546_IndexValue : EdifactComponent
{
	[Position(1)]
	public string IndexText { get; set; }

	[Position(2)]
	public string IndexRepresentationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C546_IndexValue>(this);
		validator.Required(x=>x.IndexText);
		validator.Length(x => x.IndexText, 1, 35);
		validator.Length(x => x.IndexRepresentationCode, 1, 3);
		return validator.Results;
	}
}
