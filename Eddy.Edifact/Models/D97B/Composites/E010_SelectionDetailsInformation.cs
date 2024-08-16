using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D97B.Composites;

[Segment("E010")]
public class E010_SelectionDetailsInformation : EdifactComponent
{
	[Position(1)]
	public string OptionCoded { get; set; }

	[Position(2)]
	public string AssociatedOptionInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E010_SelectionDetailsInformation>(this);
		validator.Required(x=>x.OptionCoded);
		validator.Length(x => x.OptionCoded, 1, 3);
		validator.Length(x => x.AssociatedOptionInformation, 1, 35);
		return validator.Results;
	}
}
