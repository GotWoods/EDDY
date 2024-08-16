using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("UNS")]
public class UNS_SectionControl : EdifactSegment
{
	[Position(1)]
	public string SectionIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<UNS_SectionControl>(this);
		validator.Required(x=>x.SectionIdentification);
		validator.Length(x => x.SectionIdentification, 1);
		return validator.Results;
	}
}
