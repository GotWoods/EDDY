using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ICD")]
public class ICD_InsuranceCoverDescription : EdifactSegment
{
	[Position(1)]
	public C330_InsuranceCoverType InsuranceCoverType { get; set; }

	[Position(2)]
	public C331_InsuranceCoverDetails InsuranceCoverDetails { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ICD_InsuranceCoverDescription>(this);
		validator.Required(x=>x.InsuranceCoverType);
		validator.Required(x=>x.InsuranceCoverDetails);
		return validator.Results;
	}
}
