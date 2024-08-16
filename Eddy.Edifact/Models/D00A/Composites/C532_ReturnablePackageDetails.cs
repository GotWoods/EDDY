using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D00A.Composites;

[Segment("C532")]
public class C532_ReturnablePackageDetails : EdifactComponent
{
	[Position(1)]
	public string ReturnablePackageFreightPaymentResponsibilityCode { get; set; }

	[Position(2)]
	public string ReturnablePackageLoadContentsCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C532_ReturnablePackageDetails>(this);
		validator.Length(x => x.ReturnablePackageFreightPaymentResponsibilityCode, 1, 3);
		validator.Length(x => x.ReturnablePackageLoadContentsCode, 1, 3);
		return validator.Results;
	}
}
