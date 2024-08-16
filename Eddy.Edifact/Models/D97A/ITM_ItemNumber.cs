using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("ITM")]
public class ITM_ItemNumber : EdifactSegment
{
	[Position(1)]
	public E212_ItemNumberIdentification ItemNumberIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ITM_ItemNumber>(this);
		validator.Required(x=>x.ItemNumberIdentification);
		return validator.Results;
	}
}
