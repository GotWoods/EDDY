using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D99A.Composites;

namespace Eddy.Edifact.Models.D99A;

[Segment("ICI")]
public class ICI_InsuranceCoverInformation : EdifactSegment
{
	[Position(1)]
	public E016_InsuranceCoverRequirement InsuranceCoverRequirement { get; set; }

	[Position(2)]
	public E017_MonetaryAmount MonetaryAmount { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ICI_InsuranceCoverInformation>(this);
		validator.Required(x=>x.InsuranceCoverRequirement);
		return validator.Results;
	}
}
