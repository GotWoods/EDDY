using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C546")]
public class C546_IndexValue : EdifactComponent
{
	[Position(1)]
	public string IndexValue { get; set; }

	[Position(2)]
	public string IndexValueRepresentationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C546_IndexValue>(this);
		validator.Required(x=>x.IndexValue);
		validator.Length(x => x.IndexValue, 1, 35);
		validator.Length(x => x.IndexValueRepresentationCode, 1, 3);
		return validator.Results;
	}
}
