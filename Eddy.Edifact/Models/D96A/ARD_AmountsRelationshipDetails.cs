using Eddy.Core.Attributes;
using Eddy.Core.Validation;
using Eddy.Edifact.Models.D96A.Composites;

namespace Eddy.Edifact.Models.D96A;

[Segment("ARD")]
public class ARD_AmountsRelationshipDetails : EdifactSegment
{
	[Position(1)]
	public C549_MonetaryFunction MonetaryFunction { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<ARD_AmountsRelationshipDetails>(this);
		return validator.Results;
	}
}
