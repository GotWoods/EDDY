using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("E010")]
public class E010_SelectionDetailsInformation : EdifactComponent
{
	[Position(1)]
	public string OptionCode { get; set; }

	[Position(2)]
	public string RelatedInformationDescription { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<E010_SelectionDetailsInformation>(this);
		validator.Required(x=>x.OptionCode);
		validator.Length(x => x.OptionCode, 1, 3);
		validator.Length(x => x.RelatedInformationDescription, 1, 35);
		return validator.Results;
	}
}
