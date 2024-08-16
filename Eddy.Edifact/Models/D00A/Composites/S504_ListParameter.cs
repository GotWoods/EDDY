using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("S504")]
public class S504_ListParameter : EdifactComponent
{
	[Position(1)]
	public string ListParameterQualifier { get; set; }

	[Position(2)]
	public string ListParameter { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<S504_ListParameter>(this);
		validator.Required(x=>x.ListParameterQualifier);
		validator.Required(x=>x.ListParameter);
		validator.Length(x => x.ListParameterQualifier, 1, 3);
		validator.Length(x => x.ListParameter, 1, 70);
		return validator.Results;
	}
}
