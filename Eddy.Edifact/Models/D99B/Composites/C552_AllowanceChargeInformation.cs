using Eddy.Core.Attributes;
using Eddy.Core.Validation;

namespace Eddy.Edifact.Models.D99B.Composites;

[Segment("C552")]
public class C552_AllowanceChargeInformation : EdifactComponent
{
	[Position(1)]
	public string AllowanceOrChargeNumber { get; set; }

	[Position(2)]
	public string AllowanceOrChargeIdentificationCode { get; set; }

	public override ValidationResult Validate()
	{
		var validator = new BasicValidator<C552_AllowanceChargeInformation>(this);
		validator.Length(x => x.AllowanceOrChargeNumber, 1, 35);
		validator.Length(x => x.AllowanceOrChargeIdentificationCode, 1, 3);
		return validator.Results;
	}
}
