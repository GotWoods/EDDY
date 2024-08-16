using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97B.Composites;

namespace Eddy.Edifact.Models.D97B;

[Segment("SDT")]
public class SDT_SelectionDetails : EdifactSegment
{
	[Position(1)]
	public E010_SelectionDetailsInformation SelectionDetailsInformation { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<SDT_SelectionDetails>(this);
		validator.Required(x=>x.SelectionDetailsInformation);
		return validator.Results;
	}
}
