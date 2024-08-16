using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D97A.Composites;

namespace Eddy.Edifact.Models.D97A;

[Segment("CRI")]
public class CRI_ConsumerReferenceInformation : EdifactSegment
{
	[Position(1)]
	public E967_ConsumerReferenceIdentification ConsumerReferenceIdentification { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<CRI_ConsumerReferenceInformation>(this);
		validator.Required(x=>x.ConsumerReferenceIdentification);
		return validator.Results;
	}
}
