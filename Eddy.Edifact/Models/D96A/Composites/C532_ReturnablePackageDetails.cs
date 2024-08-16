using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D96A.Composites;

[Segment("C532")]
public class C532_ReturnablePackageDetails : EdifactComponent
{
	[Position(1)]
	public string ReturnablePackageFreightPaymentResponsibilityCoded { get; set; }

	[Position(2)]
	public string ReturnablePackageLoadContentsCoded { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C532_ReturnablePackageDetails>(this);
		validator.Length(x => x.ReturnablePackageFreightPaymentResponsibilityCoded, 1, 3);
		validator.Length(x => x.ReturnablePackageLoadContentsCoded, 1, 3);
		return validator.Results;
	}
}
